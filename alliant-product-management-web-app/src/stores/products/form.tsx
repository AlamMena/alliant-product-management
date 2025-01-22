import { getCustomers } from "@/lib/customers/actions";
import { Customer } from "@/lib/customers/types";
import { Product } from "@/lib/products/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

interface State {
  product: Product | undefined;
  isOpen: boolean;
  setOpen: (state: boolean, product?: Product) => void;
}

export const useProductFormStore = create<State>((set) => ({
  product: undefined,
  isOpen: false,
  setOpen: (state: boolean, product?: Product) =>
    set({ isOpen: state, product: product }),
}));
