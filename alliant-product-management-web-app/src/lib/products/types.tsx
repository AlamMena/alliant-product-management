import { z } from "zod";

export interface Product {
  id?: number;
  name: string;
  price: number;
  category: {
    id: number;
    name: string;
  };
}
export const ProductSchema = z.object({
  id: z.number().optional(),
  name: z
    .string()
    .min(2, { message: "Name must contain at least 2 characters" })
    .max(50),
  price: z.coerce.number(),
  category: z
    .object({
      id: z.coerce.number(),
      name: z.string(),
    })
    .required(),
});
