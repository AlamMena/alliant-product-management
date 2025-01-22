import { getProducts } from "@/lib/products/actions";
import { Product } from "@/lib/products/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

interface State {
  page: number;
  pages: number;
  limit: number;
  search: string;
  products: { count: number; data: Product[] };
  getProducts: ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => Promise<void>;
}

export const useProductsStore = create<State>((set) => ({
  products: { count: 0, data: [] },
  search: "",
  page: 1,
  pages: 0,
  limit: 5,
  getProducts: async ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => {
    const products = await getProducts({ page, limit, search });
    return set({
      products: { count: products.count, data: products.data },
      page,
      limit,
      search,
      pages: Math.ceil(products.count / 5),
    });
  },
}));
