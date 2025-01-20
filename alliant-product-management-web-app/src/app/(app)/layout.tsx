import type { Metadata } from "next";
import { SideBar } from "@/components/sidebar";

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
    <div className="flex h-full w-full space-x-8">
      <SideBar />
      <main>{children}</main>
    </div>
  );
}
