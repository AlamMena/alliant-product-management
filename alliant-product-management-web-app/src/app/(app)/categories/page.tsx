import { Bredacrumb } from "@/components/breadcrumbs";
import { BalanceCard } from "@/components/customers/stats/balance-card";
import { CategoriesDataTable } from "@/components/products-categories/data-table";

export default async function CategoriesPage() {
  return (
    <div className="w-full flex flex-col space-y-2 relative">
      <div className="bg-slate-800 absolute h-80 w-full z-10 rounded-b-2xl"></div>
      <Bredacrumb
        items={[
          { title: "Home", href: "/" },
          { title: "Categories", href: "/categories" },
          { title: "All" },
        ]}
      />
      <div className="w-full space-y-4 z-20 max-w-6xl mx-auto">
        <div className="flex w-full justify-between">
          <h1 className="text-2xl w-full text-white">Categories Management</h1>
        </div>
        <div className="flex space-x-4 w-full py-4 h-full">
          {[1, 2, 3].map((item) => (
            <BalanceCard
              key={item}
              title="Active categories"
              comparePercentage={10}
              compareTitle="Compared to last month"
              balance={20}
            />
          ))}
        </div>
        <CategoriesDataTable />
      </div>
    </div>
  );
}
