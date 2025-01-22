import {
  Button,
  Chip,
  Input,
  Spinner,
  Table,
  TableBody,
  TableCell,
  TableColumn,
  TableHeader,
  TableRow,
} from "@heroui/react";
import React, { useEffect, useState } from "react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { useCustomersStore } from "@/stores/customers";
import { debounce } from "lodash";
import { CustomerForm } from "..";
import { SearchProductsModal } from "../search-products-modal";
import { Controller, useFieldArray, useFormContext } from "react-hook-form";
import { Product } from "@/lib/products/types";
import { CustomerProduct } from "@/lib/customers/types";
export const columns = [
  { name: "Id", uid: "productId" },
  { name: "Name", uid: "name" },
  { name: "Category", uid: "categoryId" },
  { name: "Price", uid: "price" },
  { name: "Quantity", uid: "actions" },
];
export const CustomerProductsTable = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [customerProducts, setCustomerProducts] = React.useState<
    CustomerProduct[]
  >([]);

  const form = useFormContext();

  useEffect(() => {
    setCustomerProducts(form.getValues("products"));
  }, [form.watch("products")]);

  const handleDeleteItem = (prodcutId: number) => {
    setIsLoading(true);
    setTimeout(() => {
      const formProducts = form.getValues("products") as CustomerProduct[];
      form.setValue(
        "products",
        formProducts.filter((d) => d.productId !== prodcutId)
      );
      setIsLoading(false);
    }, 500);
  };

  const renderCell = React.useCallback(
    (customerProduct: CustomerProduct, columnKey: React.Key) => {
      const cellValue = customerProduct[columnKey as keyof CustomerProduct];
      const index = (form.getValues("products") as CustomerProduct[]).findIndex(
        (d) => d.productId === customerProduct.productId
      );
      switch (columnKey) {
        case "name":
          return <span className="w-full">{cellValue}</span>;
        case "categoryId":
          return (
            <Chip className="capitalize" size="sm" variant="flat">
              Category name
            </Chip>
          );
        case "price":
          return (
            <Input
              variant="faded"
              className="w-full"
              size="sm"
              placeholder="1"
              type="number"
              {...form.register(`products[${index}].price`)}
            />
          );
        case "actions":
          return (
            <div className="flex space-x-2">
              <Input
                variant="faded"
                className="w-full"
                size="sm"
                placeholder="1"
                {...form.register(`products[${index}].quantity`)}
              />
              <Button
                size="sm"
                onPress={() => handleDeleteItem(customerProduct.productId)}
                isIconOnly
                color="danger"
                startContent={
                  <Icon
                    icon="solar:trash-bin-minimalistic-2-outline"
                    width={16}
                    height={16}
                  />
                }
              />
            </div>
          );
        default:
          return cellValue;
      }
    },
    []
  );
  const loadingState = isLoading ? "loading" : "idle";
  return (
    <div className="flex flex-col gap-4 w-full">
      <div className="flex space-x-2 items-center">
        <span className="text-xl">Customer products</span>
        <SearchProductsModal />
      </div>
      <Table
        aria-label="Example static collection table"
        color={"primary"}
        removeWrapper
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
          items={customerProducts}
        >
          {customerProducts.map((item, index) => (
            <TableRow key={item.productId}>
              {(columnKey) => (
                <TableCell>{renderCell(item, columnKey)}</TableCell>
              )}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};
