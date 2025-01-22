import { getCustomers } from "@/lib/customers/actions";
import { Customer } from "@/lib/customers/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

interface State {
  page: number;
  pages: number;
  limit: number;
  search: string;
  customers: { count: number; data: Customer[] };
  getCustomers: ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => Promise<void>;
}

export const useCustomersStore = create<State>((set) => ({
  customers: { count: 0, data: [] },
  search: "",
  page: 1,
  pages: 0,
  limit: 5,
  getCustomers: async ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => {
    const customers = await getCustomers({ page, limit, search });
    return set({
      customers: { count: customers.count, data: customers.data },
      page,
      limit,
      search,
      pages: Math.ceil(customers.count / 5),
    });
  },
}));
