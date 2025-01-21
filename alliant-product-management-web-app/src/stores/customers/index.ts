import { getCustomers } from "@/lib/customers/actions";
import { Customer } from "@/lib/customers/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

interface State {
  page: number;
  pages: number;
  limit: number;
  customers: { count: number; data: Customer[] };
  getCustomers: ({
    page,
    limit,
  }: {
    page: number;
    limit: number;
  }) => Promise<void>;
}

export const useCustomersStore = create<State>((set) => ({
  customers: { count: 0, data: [] },
  page: 1,
  pages: 0,
  limit: 5,
  getCustomers: async ({ page, limit }: { page: number; limit: number }) => {
    const customers = await getCustomers({ page, limit });
    return set({
      customers: { count: customers.count, data: customers.data },
      page,
      limit,
      pages: Math.ceil(customers.count / 5),
    });
  },
}));
