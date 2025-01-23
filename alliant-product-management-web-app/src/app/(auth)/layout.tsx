import { Metadata } from "next";
import { ReactNode } from "react";

export const metadata: Metadata = {
  title: "Auth | Alliant clients",
  description: "",
};
export default function AuthLayout({ children }: { children: ReactNode }) {
  return (
    <div className="flex flex-col h-screen w-full items-center justify-center">
      {children}
    </div>
  );
}
