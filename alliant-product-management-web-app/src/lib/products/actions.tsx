"use server";
import { revalidatePath } from "next/cache";
import { AxiosError } from "axios";
import { axiosInstance } from "../common/instance";
import { ApiResponse } from "../common/api-response";
import { Product } from "./types";

export async function saveProduct(
  product: Product
): Promise<ApiResponse<Product>> {
  try {
    let response: ApiResponse<Product>;
    if (!product.id) {
      const res = await axiosInstance.post(`product`, product);
      response = res.data;
    } else {
      const res = await axiosInstance.put(`product`, product);
      response = res.data;
      revalidatePath("/products");
    }
    return response;
  } catch (error) {
    console.log(error);
    const parsedError = error as AxiosError;
    const apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Product>;

    return {
      message: apiResponse?.message ?? "An error has ocurred",
      status: parsedError.status,
    };
  }
}
export async function getProducts({
  page,
  search,
  limit,
}: {
  page: number;
  search?: string;
  limit: number;
}) {
  const searchParams = search?.replace(/\s/g, "") ? `&filter=${search}` : "";
  const { data } = await axiosInstance.get(
    `products/filtered?page=${page ?? 1}&limit=${limit}${searchParams}`
  );
  console.log(data);
  return data as { count: number; data: Product[] };
}

export async function deleteProduct(
  product: Product
): Promise<ApiResponse<Product>> {
  try {
    const res = await axiosInstance.delete(`product/` + product.id);
    const response: ApiResponse<Product> = {
      data: res.data,
    };
    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    const apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Product>;
    return {
      message: apiResponse.message,
      status: parsedError.status,
    };
  }
}

export async function getProductById({ id }: { id: number }) {
  const { data } = await axiosInstance.get(`product/${id}`);
  return data as Product;
}
