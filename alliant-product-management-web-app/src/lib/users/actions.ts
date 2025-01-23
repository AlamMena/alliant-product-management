"use server";
import { sealData, unsealData } from "iron-session";
import { LogInSchema, RegisterSchema, User } from "./types";
import { ApiResponse } from "../common/api-response";
import { axiosInstance } from "../common/instance";
import { z } from "zod";
import { AxiosError } from "axios";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export async function logIn(
  credentials: z.infer<typeof LogInSchema>
): Promise<ApiResponse<User>> {
  const response: ApiResponse<User> = {
    message: "",
  };
  try {
    console.log(process.env.API_URL);
    const { data } = await axiosInstance.post("user/login", {
      email: credentials.email,
      password: credentials.password,
    });
    await setSession(data as User);
    return response;
  } catch (error) {
    const parsedResponse = error as unknown as AxiosError;
    response.message =
      parsedResponse.status === 400
        ? "Invalid credentials"
        : "An error has occured";
    return response;
  }
}

export async function register(
  credentials: z.infer<typeof RegisterSchema>
): Promise<ApiResponse<User>> {
  const response: ApiResponse<User> = {
    message: "",
  };
  try {
    console.log(process.env.API_URL);
    const { data } = await axiosInstance.post("user", {
      username: credentials.username,
      email: credentials.email,
      password: credentials.password,
    });
    await setSession(data as User);
    return response;
  } catch (error) {
    const parsedError = error as unknown as AxiosError;
    const parsedResponse = parsedError.response?.data as ApiResponse<User>;
    console.log(parsedError.status);
    response.message =
      parsedError.status === (400 | 409)
        ? parsedResponse.message
        : "An error has occured";
    return response;
  }
}

async function setSession(user: User) {
  const cookieStore = await cookies();
  const encryptedSession = await sealData(JSON.stringify(user), {
    password: process.env.SESSION_KEY as string,
  });
  cookieStore.set("session", encryptedSession);
}
export async function getSession(): Promise<User | null> {
  const cookieStore = await cookies();
  const cookieSession = cookieStore.get("session")?.value ?? "";

  if (!cookieSession) {
    return null;
  }

  const session = await unsealData(cookieSession, {
    password: process.env.SESSION_KEY as string,
  });

  return JSON.parse(session as string) as User;
}

export async function logOut() {
  const cookieStore = await cookies();
  const cookieSession = cookieStore.get("session")?.value ?? "";

  if (!cookieSession) {
    return null;
  }

  cookieStore.delete("session");

  redirect("/login");
}
