"use server";
import { AxiosError } from "axios";
import { ApiResponse } from "../common/api-response";
import { axiosInstance } from "../common/instance";
import { ProductCategory } from "./types";
import { revalidatePath } from "next/cache";

export async function getCategories({
  page,
  search,
  limit,
}: {
  page: number;
  search?: string;
  limit: number;
}) {
  const searchParams = search ? `&filter=${search}` : "";
  const { data } = await axiosInstance.get(
    `product/categories?page=${page ?? 1}&limit=${limit}`
  );
  return data as { count: number; data: ProductCategory[] };
}
export async function deleteCategory(
  category: ProductCategory
): Promise<ApiResponse<ProductCategory>> {
  try {
    let response: ApiResponse<ProductCategory>;
    const res = await axiosInstance.delete(`product/category/` + category.id);
    response = res.data;
    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<ProductCategory>;
    return {
      message: apiResponse.message,
      status: parsedError.status,
    };
  }
}

export async function getCategoryById({ id }: { id: number }) {
  const { data } = await axiosInstance.get(`product/category/${id}`);
  return data as ProductCategory;
}

export async function saveCategory(
  category: ProductCategory
): Promise<ApiResponse<ProductCategory>> {
  try {
    let response: ApiResponse<ProductCategory>;
    if (!category.id) {
      const res = await axiosInstance.post(`product/category`, category);
      response = res.data;
    } else {
      const res = await axiosInstance.put(`product/category`, category);
      response = res.data;
      revalidatePath("/categories");
    }
    return response;
  } catch (error) {
    console.log(error);
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<ProductCategory>;

    return {
      message: apiResponse?.message ?? "An error has ocurred",
      status: parsedError.status,
    };
  }
}
