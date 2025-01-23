import z from "zod";
export interface User {
  username?: string;
  email: string;
  token?: string;
}
export const LogInSchema = z.object({
  email: z.string().email({ message: "Email must be a valid email" }),
  password: z.string().min(6, "Passowrd must contain at least 6 characters"),
});

export const RegisterSchema = z.object({
  username: z.string(),
  email: z.string().email({ message: "Email must be a valid email" }),
  password: z.string().min(6, "Passowrd must contain at least 6 characters"),
});
