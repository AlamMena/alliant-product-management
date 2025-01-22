import { getCustomers } from "@/lib/customers/actions";
import { Customer } from "@/lib/customers/types";
import { ProductCategory } from "@/lib/products-categories/types";
import { Product } from "@/lib/products/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

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
