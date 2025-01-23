import { Customer } from "@/lib/customers/types";
import { create } from "zustand";

interface State {
  customer: Customer | undefined;
  isOpen: boolean;
  setOpen: (state: boolean, customer?: Customer) => void;
}

export const useCustomerFormStore = create<State>((set) => ({
  customer: undefined,
  isOpen: false,
  setOpen: (state: boolean, customer?: Customer) =>
    set({ isOpen: state, customer: customer }),
}));
