"use client";

import { formatCurrency } from "@/lib/core";
import { CustomerProduct } from "@/lib/customers/types";
import { getProducts } from "@/lib/products/actions";
import { Product } from "@/lib/products/types";
import {
  Button,
  Chip,
  Input,
  Modal,
  ModalContent,
  Pagination,
  Selection,
  Spinner,
  Table,
  TableBody,
  TableCell,
  TableColumn,
  TableHeader,
  TableRow,
  useDisclosure,
  User,
} from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { debounce } from "lodash";
import React from "react";
import { useEffect, useState } from "react";
import { useFormContext } from "react-hook-form";
import { array } from "zod";

export const columns = [
  { name: "Id", uid: "id" },
  { name: "Name", uid: "name" },
  { name: "Price", uid: "price" },
  { name: "Category", uid: "categoryId" },
];

export function SearchProductsModal() {
  const [isLoading, setIsLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [pages, setPages] = useState<number>(1);
  const [products, setProducts] = useState<Product[]>([]);
  const [selectedKeys, setSelectedKeys] = useState<Selection>();
  const [filterValue, setFilterValue] = useState("");
  const { onOpen, isOpen, onOpenChange, onClose } = useDisclosure();
  const form = useFormContext();

  const renderCell = React.useCallback(
    (product: Product, columnKey: React.Key) => {
      switch (columnKey) {
        case "name":
          return <span className="w-full">{product.name}</span>;
        case "price":
          return <span>{formatCurrency(product.price)}</span>;
        case "categoryId":
          return (
            <Chip className="capitalize" size="sm" variant="flat">
              Category name
            </Chip>
          );
      }
    },
    []
  );

  const handleAddProduct = async () => {
    setIsLoading(true);
    let formProducts = form.getValues("products") as CustomerProduct[];
    let productsSelected = products;

    const allSelected = Array.from(selectedKeys ?? "")
      .join(", ")
      .replaceAll("_", " ")
      .includes("a");

    if (!allSelected) {
      // parsing keys to number
      const keys = Array.from(selectedKeys ?? [])
        .map((key) => {
          if (typeof key === "string") {
            // Use replaceAll for strings
            return Number(key.replaceAll("_", " "));
          }
          return Number(key);
        })
        .filter((key) => !isNaN(key));

      productsSelected = products.filter((d) => keys.includes(d.id ?? 0));
    }

    productsSelected.map((product) => {
      formProducts.push({
        id: undefined,
        name: product.name,
        productId: product.id ?? 0,
        price: product.price,
        quantity: 1,
        category: product.category,
      });
    });

    form.setValue("products", formProducts);
    onClose();
    await handleGetProducts();
    setIsLoading(false);
  };

  const handleGetProducts = async (value?: string, page?: number) => {
    setIsLoading(true);
    const products = await getProducts({
      page: page ?? 1,
      limit: 5,
      search: value,
    });

    setPages(Math.ceil(products.count / 5));
    const formProducts = form.getValues("products") as CustomerProduct[];

    const filterdProducts = products.data.filter(
      (product) => !formProducts.find((d) => d.productId === product.id)
    );
    setProducts(filterdProducts);
    setIsLoading(false);
  };
  // Debounce the API call
  const debouncedSearch = React.useMemo(
    () =>
      debounce(async (value: string) => {
        await handleGetProducts(value);
      }, 300),
    []
  );

  const onSearchChange = React.useCallback(
    (value?: string) => {
      if (value) {
        setFilterValue(value);
      } else {
        setFilterValue("");
      }
      // Call the debounced function
      debouncedSearch(value || "");
    },
    [debouncedSearch]
  );

  const onPageChange = async (page: number) => {
    setPage(page);
    await handleGetProducts(filterValue, page);
  };

  // Cleanup the debounce function on component unmount
  React.useEffect(() => {
    return () => {
      debouncedSearch.cancel();
    };
  }, [debouncedSearch]);

  const loadingState = isLoading ? "loading" : "idle";
  return (
    <>
      <Button
        size="sm"
        onPress={onOpen}
        isIconOnly
        variant="shadow"
        color="primary"
        startContent={
          <Icon icon="solar:add-circle-outline" width={16} height={16} />
        }
      />
      <Modal isOpen={isOpen} onOpenChange={onOpenChange} hideCloseButton>
        <ModalContent className="flex flex-col space-y-4 p-6 w-full max-w-xl">
          <span>Find products for your customer</span>
          <div className="w-full flex gap-3 items-center">
            <Input
              variant="faded"
              isClearable
              placeholder="Search your products"
              startContent={
                <Icon icon="solar:magnifer-outline" width={16} height={16} />
              }
              value={filterValue}
              fullWidth
              onValueChange={(e) => onSearchChange(e)}
            />
            <Button
              onPress={handleAddProduct}
              variant="shadow"
              color="primary"
              isIconOnly
              startContent={
                <Icon icon="solar:add-circle-outline" width={24} height={24} />
              }
            />
          </div>

          <div className="flex flex-col gap-3 w-full">
            <Table
              bottomContent={
                <div className="p-2 flex justify-center items-center">
                  <Pagination
                    isCompact
                    showControls
                    showShadow
                    color="primary"
                    page={page}
                    total={pages}
                    onChange={onPageChange}
                  />
                </div>
              }
              aria-label="Example static collection table"
              color={"primary"}
              selectionBehavior="toggle"
              selectionMode="multiple"
              selectedKeys={selectedKeys}
              onSelectionChange={setSelectedKeys}
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
                items={products}
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
        </ModalContent>
      </Modal>
    </>
  );
}
