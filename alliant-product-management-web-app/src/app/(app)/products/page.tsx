import { Bredacrumb } from "@/components/breadcrumbs";
import { ProductsDataTable } from "@/components/products/data-table";

export default async function ProductsPage() {
  return (
    <div className="w-full flex flex-col space-y-2 relative">
      <div className="bg-slate-800 absolute h-80 w-full z-10 rounded-b-2xl"></div>
      <Bredacrumb
        items={[
          { title: "Home", href: "/" },
          { title: "Products", href: "/products" },
          { title: "All" },
        ]}
      />
      <div className="w-full space-y-4 z-20 max-w-6xl mx-auto">
        <div className="flex w-full justify-between">
          <h1 className="text-2xl w-full text-white">Products Management</h1>
        </div>
        {/* <div className="flex space-x-4 w-full py-4">
          {[1, 2, 3].map((item) => (
            <BalanceCard key={item} />
          ))}
        </div> */}
        <ProductsDataTable />
      </div>
    </div>
  );
}
