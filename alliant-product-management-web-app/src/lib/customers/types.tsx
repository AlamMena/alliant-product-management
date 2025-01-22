import z from "zod";

const CustomerProductSchema = z.object({
  id: z.number().optional(),
  name: z.string().optional(),
  productId: z.number().optional(),
  price: z.coerce.number().optional(),
  quantity: z.coerce.number().optional(),
});
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
  products: CustomerProductSchema.array().optional(),
});

export interface Customer {
  id?: number;
  name: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  identification: string;
  products?: CustomerProduct[];
}

export interface CustomerProduct {
  id?: number;
  name: string;
  price: number;
  quantity: number;
  productId: number;
}
