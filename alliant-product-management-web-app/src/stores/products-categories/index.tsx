import { getCategories } from "@/lib/products-categories/actions";
import { ProductCategory } from "@/lib/products-categories/types";
import { create } from "zustand";

interface State {
  page: number;
  pages: number;
  limit: number;
  search: string;
  categories: { count: number; data: ProductCategory[] };
  getCategories: ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => Promise<void>;
}

export const useProductCategoriesStore = create<State>((set) => ({
  categories: { count: 0, data: [] },
  search: "",
  page: 1,
  pages: 0,
  limit: 5,
  getCategories: async ({
    page,
    limit,
    search,
  }: {
    page: number;
    limit: number;
    search?: string;
  }) => {
    const categories = await getCategories({ page, limit, search });
    return set({
      categories: { count: categories.count, data: categories.data },
      page,
      limit,
      search,
      pages: Math.ceil(categories.count / 5),
    });
  },
}));
