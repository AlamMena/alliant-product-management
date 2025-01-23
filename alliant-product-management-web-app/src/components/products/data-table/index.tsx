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
import { ConfirmationModal } from "@/components/common/confirmation-modal";
import { displayToast } from "@/components/toast";
import { useProductsStore } from "@/stores/products";
import { Product } from "@/lib/products/types";
import { useProductFormStore } from "@/stores/products/form";
import { deleteProduct } from "@/lib/products/actions";
import { ProductForm } from "../form";
import { formatCurrency } from "@/lib/core";

export const columns = [
  { name: "Id", uid: "id" },
  { name: "Name", uid: "name" },
  { name: "Price", uid: "price" },
  { name: "Category", uid: "category" },
  { name: "Actions", uid: "actions" },
];

export function ProductsDataTable() {
  // states
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [page, setPage] = React.useState(1);

  // stores
  const { products, getProducts, pages } = useProductsStore();
  const { setOpen } = useProductFormStore();

  // functions
  useEffect(() => {
    async function handleGetProducts() {
      setIsLoading(true);
      await getProducts({ page, limit: 5 });
      setIsLoading(false);
    }
    handleGetProducts();
  }, [page]);

  const handleDeleteProduct = async (product: Product) => {
    const response = await deleteProduct(product);
    if (response.message) {
      displayToast({
        title: "Error removing the product",
        description: response.message,
        type: "error",
      });
    }
    await getProducts({ page: 1, limit: 5 });
    displayToast({
      title: "Product removed",
      description: `The product with id: ${product.id} has been removed.`,
      type: "success",
    });
  };

  const renderCell = (product: Product, columnKey: React.Key) => {
    switch (columnKey) {
      case "id":
        return <span>{product.id}</span>;
      case "name":
        return (
          <User avatarProps={{ radius: "sm", src: "" }} name={product.name} />
        );
      case "price":
        return <span>{formatCurrency(product.price)}</span>;
      case "category":
        return (
          <Chip className="capitalize" size="sm" variant="flat">
            {product.category.name}
          </Chip>
        );

      case "actions":
        return (
          <div className="relative flex items-center">
            <Button
              isIconOnly
              variant="light"
              onPress={() => {
                setOpen(true, product);
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
              description={`Once this action is confirm the customer ${product.name} will be remove.`}
              onCancel={() => {}}
              onConfirm={() => handleDeleteProduct(product)}
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
      <ProductForm />
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
          items={products.data}
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
