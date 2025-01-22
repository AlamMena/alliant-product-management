import { z } from "zod";

export interface ProductCategory {
  id: number;
  name: string;
  description: string;
}
export const CategorySchema = z.object({
  id: z.number().optional(),
  name: z
    .string()
    .min(2, { message: "Name must contain at least 2 characters" })
    .max(50),
  description: z.string(),
});
