import z from "zod";
export const CustomerSchema = z.object({
  id: z.number().optional(),
  name: z
    .string()
    .min(2, { message: "Name must contain at least 2 characters" })
    .max(50),
  lastName: z
    .string()
    .min(2, { message: "Last name must contain at least 2 characters" })
    .max(50),
  identification: z
    .string()
    .min(5, { message: "Identification must contain at least 5 characters" })
    .max(50),
  email: z
    .string()
    .email({ message: "Email must be a valid email" })
    .nullable()
    .optional(),
  phoneNumber: z.string().min(2),
});

export interface Customer {
  id?: number;
  name: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  identification: string;
}
