import { ProductCategory } from "@/lib/products-categories/types";
import { create } from "zustand";

interface State {
  category: ProductCategory | undefined;
  isOpen: boolean;
  setOpen: (state: boolean, category?: ProductCategory) => void;
}

export const useProductCategoriesFormStore = create<State>((set) => ({
  category: undefined,
  isOpen: false,
  setOpen: (state: boolean, category?: ProductCategory) =>
    set({ isOpen: state, category: category }),
}));
