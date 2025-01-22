import { getCustomers } from "@/lib/customers/actions";
import { Customer } from "@/lib/customers/types";
import { create } from "zustand";
// import { CoincidencePersonResponse } from "../search/types";

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
