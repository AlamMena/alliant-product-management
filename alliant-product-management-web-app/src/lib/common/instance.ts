import axios, { AxiosError } from "axios";
import { redirect } from "next/navigation";
import { getSession } from "../users/actions";

export const axiosInstance = axios.create({
  baseURL: process.env.API_URL,
  headers: { "X-Custom-Header": "foobar" },
});

axiosInstance.interceptors.request.use(
  async function (config) {
    const session = await getSession();
    config.headers.Authorization = `Bearer ${session?.token}`;
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);
axiosInstance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error: AxiosError) {
    if (error.status === 401) {
      console.log("Unauthorized");
      redirect("/login");
    }
    return Promise.reject(error);
  }
);
