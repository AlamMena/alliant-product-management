"use client";
import React, { useEffect, useState } from "react";
import {
  Table,
  TableHeader,
  TableColumn,
  TableBody,
  TableRow,
  TableCell,
  User,
  Chip,
  Tooltip,
  Spinner,
  Button,
} from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { TopContent } from "./top-content";
import { BottomContent } from "./bottom-content";
import { Customer } from "@/lib/customers/types";
import { useCustomersStore } from "@/stores/customers";
import { CustomerForm } from "../form";
import { ConfirmationModal } from "@/components/common/confirmation-modal";
import { deleteCustomer } from "@/lib/customers/actions";
import { displayToast } from "@/components/toast";
import { useCustomerFormStore } from "@/stores/customers/form";

export const columns = [
  { name: "Id", uid: "id" },
  { name: "Name", uid: "name" },
  { name: "Phone", uid: "phoneNumber" },
  { name: "Identification", uid: "identification" },
  { name: "Actions", uid: "actions" },
];

export function CustomersDataTable() {
  // states
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [page, setPage] = React.useState(1);

  // stores
  const { customers, getCustomers, pages } = useCustomersStore();
  const { setOpen } = useCustomerFormStore();

  // functions
  useEffect(() => {
    async function handleGetCustomers() {
      setIsLoading(true);
      await getCustomers({ page, limit: 5 });
      setIsLoading(false);
    }
    handleGetCustomers();
  }, [page]);

  const handleDeleteCustomer = async (customer: Customer) => {
    const response = await deleteCustomer(customer);
    if (response.message) {
      displayToast({
        title: "Error removing the customer",
        description: response.message,
        type: "error",
      });
      return;
    }
    await getCustomers({ page: 1, limit: 5 });

    displayToast({
      title: "Customer removed",
      description: `The customer with id: ${customer.id} has been removed.`,
      type: "success",
    });
  };

  const renderCell = (customer: Customer, columnKey: React.Key) => {
    switch (columnKey) {
      case "id":
        return <span>{customer.id}</span>;
      case "name":
        return (
          <User
            avatarProps={{ radius: "full", src: "" }}
            name={customer.name}
            description={customer.email}
          >
            {customer.email}
          </User>
        );
      case "phoneNumber":
        return <p>{customer.phoneNumber}</p>;
      case "status":
        return (
          <Chip className="capitalize" size="sm" variant="flat">
            {customer.phoneNumber}
          </Chip>
        );
      case "identification":
        return <span>{customer.identification}</span>;
      case "actions":
        return (
          <div className="relative flex items-center">
            <Button
              isIconOnly
              variant="light"
              onPress={() => {
                setOpen(true, customer);
              }}
              startContent={
                <Tooltip content="Edit user">
                  <Icon
                    icon="solar:pen-outline"
                    className=" text-default-400 cursor-pointer"
                    width={20}
                    height={20}
                  />
                </Tooltip>
              }
            />

            <ConfirmationModal
              description={`Once this action is confirm the customer ${customer.name} will be remove.`}
              onCancel={() => {}}
              onConfirm={() => handleDeleteCustomer(customer)}
              triggerContent={
                <Button
                  isIconOnly
                  variant="light"
                  startContent={
                    <Tooltip color="danger" content="Delete user">
                      <Icon
                        icon="solar:trash-bin-minimalistic-2-outline"
                        className="text-lg text-danger cursor-pointer active:opacity-50"
                        height={20}
                        width={20}
                      />
                    </Tooltip>
                  }
                />
              }
            />
          </div>
        );
    }
  };

  const loadingState = isLoading ? "loading" : "idle";

  return (
    <div className="flex flex-col gap-3 w-full">
      <CustomerForm />
      <Table
        aria-label="Example static collection table"
        color={"primary"}
        topContent={<TopContent />}
        bottomContent={
          <BottomContent onPageChange={setPage} page={page} pages={pages} />
        }
        classNames={{
          wrapper: "py-8 px-6",
          table: "border-separate border-spacing-y-2 ",
          tr: "outline outline-1 rounded-xl outline-slate-200 cursor-pointer",
          td: "",
        }}
      >
        <TableHeader columns={columns}>
          {(column) => (
            <TableColumn
              key={column.uid}
              align={column.uid === "actions" ? "center" : "start"}
            >
              {column.name}
            </TableColumn>
          )}
        </TableHeader>
        <TableBody
          emptyContent={"No data found"}
          loadingContent={<Spinner />}
          loadingState={loadingState}
          items={customers.data}
        >
          {(item) => (
            <TableRow key={item.id}>
              {(columnKey) => (
                <TableCell>{renderCell(item, columnKey)}</TableCell>
              )}
            </TableRow>
          )}
        </TableBody>
      </Table>
    </div>
  );
}
