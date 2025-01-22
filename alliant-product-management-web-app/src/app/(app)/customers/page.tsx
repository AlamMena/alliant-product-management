import { Bredacrumb } from "@/components/breadcrumbs";
import { CustomersDataTable } from "@/components/customers/data-table";
import { CustomerForm } from "@/components/customers/form";
import { BalanceCard } from "@/components/customers/stats/balance-card";
import CustomersToolBar from "@/components/customers/toolbar";
import {
  getAcquisitionsBalanceByDate,
  getAcquisitionsByDate,
  getCustomers,
  getCustomersCreatedByDate,
} from "@/lib/customers/actions";
import { Button } from "@heroui/react";

export default async function CustomersPage() {
  const customersCreatedByDate = await getCustomersCreatedByDate();
  const customersAcquisitions = await getAcquisitionsByDate();
  const customersAcquisitionsBalance = await getAcquisitionsBalanceByDate();

  return (
    <div className="w-full flex flex-col space-y-2 relative">
      <div className="bg-slate-800 absolute h-80 w-full z-10 rounded-b-2xl"></div>
      <Bredacrumb
        items={[
          { title: "Home", href: "/" },
          { title: "Customers", href: "/customers" },
          { title: "All" },
        ]}
      />
      <div className="w-full space-y-4 z-20 max-w-6xl mx-auto">
        <div className="flex w-full justify-between">
          <h1 className="text-2xl w-full text-white">Customers Management</h1>
        </div>
        <div className="flex space-x-4 w-full py-4">
          <BalanceCard key={"customers"} report={customersCreatedByDate} />
          <BalanceCard
            key={"customers acquisitions quantity"}
            report={customersAcquisitions}
          />
          <BalanceCard
            key={"customers acquisitions balance"}
            report={customersAcquisitionsBalance}
          />
        </div>
        <CustomersDataTable />
      </div>
    </div>
  );
}
