"use server";
import { revalidatePath } from "next/cache";
import { Customer } from "./types";
import { AxiosError } from "axios";
import { axiosInstance } from "../common/instance";
import { ApiResponse } from "../common/api-response";
import { DateReport } from "../common/date-report";

export async function saveCustomer(
  customer: Customer
): Promise<ApiResponse<Customer>> {
  try {
    console.log(customer, "res");

    let response: ApiResponse<Customer>;
    if (!customer.id) {
      const res = await axiosInstance.post(`customer`, customer);
      response = res.data;
    } else {
      const res = await axiosInstance.put(`customer`, customer);
      console.log(customer, "res");
      response = res.data;
      revalidatePath("/");
    }
    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Customer>;

    return {
      message: apiResponse?.message ?? "An error has ocurred",
      status: parsedError.status,
    };
  }
}
export async function getCustomers({
  page,
  search,
  limit,
}: {
  page: number;
  search?: string;
  limit: number;
}) {
  const searchParams = search?.replace(/\s/g, "") ? `&name=${search}` : "";
  const { data } = await axiosInstance.get(
    `customers/filtered?page=${page ?? 1}&limit=${limit}` + searchParams
  );
  return data as { count: number; data: Customer[] };
}

export async function getCustomerById({ id }: { id: number }) {
  const { data } = await axiosInstance.get(`customer/${id}`);
  return data as Customer;
}

export async function deleteCustomer(
  customer: Customer
): Promise<ApiResponse<Customer>> {
  try {
    let response: ApiResponse<Customer>;
    const res = await axiosInstance.delete(`customer/` + customer.id);
    response = res.data;
    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Customer>;
    return {
      message: apiResponse.message,
      status: parsedError.status,
    };
  }
}
export async function getCustomersCreatedByDate() {
  const { data } = await axiosInstance.get(`customers/reports/createdByDate`);
  return data as DateReport;
}
export async function getAcquisitionsByDate() {
  const { data } = await axiosInstance.get(
    `customers/reports/acquisitions/quantity`
  );
  return data as DateReport;
}
export async function getAcquisitionsBalanceByDate() {
  const { data } = await axiosInstance.get(
    `customers/reports/acquisitions/balance`
  );
  return data as DateReport;
}
