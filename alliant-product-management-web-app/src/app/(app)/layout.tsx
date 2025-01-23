import type { Metadata } from "next";
import { AppNavbar } from "@/components/nav";

export const metadata: Metadata = {
  title: "Alliant | Customers",
  description: "Alliant clients management",
};

export default function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <div className="m-2">
      <AppNavbar />
      <div className="w-full h-full pb-10 flex flex-col space-y-4 items-center">
        {children}
      </div>
    </div>
  );
}
