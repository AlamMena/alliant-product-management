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
  Tooltip,
  Spinner,
  Button,
} from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { TopContent } from "./top-content";
import { BottomContent } from "./bottom-content";
import { ConfirmationModal } from "@/components/common/confirmation-modal";
import { displayToast } from "@/components/toast";
import { useProductCategoriesFormStore } from "@/stores/products-categories/form";
import { useProductCategoriesStore } from "@/stores/products-categories";
import { ProductCategory } from "@/lib/products-categories/types";
import { deleteCategory } from "@/lib/products-categories/actions";
import { CategoryForm } from "../form";

export const columns = [
  { name: "Id", uid: "id" },
  { name: "Name", uid: "name" },
  { name: "Description", uid: "description" },
  { name: "Actions", uid: "actions" },
];

export function CategoriesDataTable() {
  // states
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [page, setPage] = React.useState(1);

  // stores
  const { categories, getCategories, pages } = useProductCategoriesStore();
  const { setOpen } = useProductCategoriesFormStore();

  // functions
  useEffect(() => {
    async function handleGetCategories() {
      setIsLoading(true);
      await getCategories({ page, limit: 5 });
      setIsLoading(false);
    }
    handleGetCategories();
  }, [page]);

  const handleDeleteCategory = async (category: ProductCategory) => {
    const response = await deleteCategory(category);
    if (response.message) {
      displayToast({
        title: "Error removing the category",
        description: response.message,
        type: "error",
      });
      return;
    }
    await getCategories({ page: 1, limit: 5 });
    displayToast({
      title: "Category removed",
      description: `The category with id: ${category.id} has been removed.`,
      type: "success",
    });
  };

  const renderCell = (category: ProductCategory, columnKey: React.Key) => {
    switch (columnKey) {
      case "id":
        return <span>{category.id}</span>;
      case "name":
        return (
          <User avatarProps={{ radius: "sm", src: "" }} name={category.name} />
        );
      case "description":
        return (
          <div className="flex flex-col">
            <p className="text-bold text-sm capitalize text-default-400">
              {category.description}
            </p>
          </div>
        );

      case "actions":
        return (
          <div className="relative flex items-center">
            <Button
              isIconOnly
              variant="light"
              onPress={() => {
                setOpen(true, category);
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
              description={`Once this action is confirm the customer ${category.name} will be remove.`}
              onCancel={() => {}}
              onConfirm={() => handleDeleteCategory(category)}
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
      <CategoryForm />
      <Table
        aria-label="categories data table"
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
          items={categories.data}
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
