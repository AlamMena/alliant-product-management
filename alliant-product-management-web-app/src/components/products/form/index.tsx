"use client";
import React, { useEffect, useState } from "react";
import {
  Input,
  Button,
  Textarea,
  Drawer,
  DrawerContent,
  Spinner,
  Autocomplete,
  AutocompleteItem,
} from "@heroui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { Controller, FormProvider, useForm } from "react-hook-form";
import z from "zod";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { displayToast } from "@/components/toast";
import { Product, ProductSchema } from "@/lib/products/types";
import { useProductsStore } from "@/stores/products";
import { useProductFormStore } from "@/stores/products/form";
import { getProductById, saveProduct } from "@/lib/products/actions";
import { ProductCategory } from "@/lib/products-categories/types";
import { getCategories } from "@/lib/products-categories/actions";

export function ProductForm() {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const [categories, setCategories] = useState<ProductCategory[]>([]);
  const { getProducts } = useProductsStore();
  const { setOpen, isOpen, product } = useProductFormStore();

  const defaultValues = {
    id: undefined,
    name: "",
    price: 0,
  };
  const form = useForm<z.infer<typeof ProductSchema>>({
    resolver: zodResolver(ProductSchema),
    defaultValues,
  });

  useEffect(() => {
    const handleGetCategories = async () => {
      const categories = await getCategories({
        page: 1,
        limit: 100,
      });
      setCategories(categories?.data);
    };
    const handleGetProduct = async () => {
      if (product?.id) {
        setIsLoading(true);
        const response = await getProductById({ id: product?.id ?? 0 });
        form.reset(response);
        console.log(response, "respoinse");
        setIsLoading(false);
      } else {
        form.reset(defaultValues);
      }
    };
    handleGetCategories();
    handleGetProduct();
  }, [product]);

  const onSubmit = async (values: z.infer<typeof ProductSchema>) => {
    setIsLoading(true);
    const response = await saveProduct(values as Product);
    setIsLoading(false);
    if (response.message) {
      displayToast({
        title: "Error saving the product",
        description: response.message,
        type: "error",
      });
      return;
    }
    setOpen(false);
    displayToast({
      title: "Product saved",
      description: "The product has been saved.",
      type: "success",
    });
    await getProducts({ page: 1, limit: 5 });
    form.reset({});
  };

  return (
    <Drawer
      isOpen={isOpen}
      onOpenChange={() => {
        setOpen(false);
        form.reset(defaultValues);
      }}
    >
      <DrawerContent className="p-8 max-w-xl w-full ">
        {isLoading ? (
          <Spinner className="absolute inset-0">Loading ...</Spinner>
        ) : (
          (onClose) => (
            <FormProvider {...form}>
              <div className="flex flex-col space-y-2 mb-8">
                <>
                  <span className=" text-2xl">Product form</span>
                  <span className=" text-sm text-foreground-400 ">
                    Fill the required fields and start managing your product 📝
                  </span>
                </>
              </div>
              <form
                className="justify-center items-center w-full space-y-8 flex flex-col"
                onSubmit={form.handleSubmit(onSubmit)}
              >
                <div className="flex w-full space-x-4 items-center">
                  <Controller
                    name="name"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        isRequired
                        label="Name"
                        labelPlacement="outside"
                        placeholder="Product name"
                        value={field.value}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:user-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                      />
                    )}
                  />
                </div>
                <div className="w-full flex flex-row flex-wrap gap-4">
                  <Controller
                    name="price"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        isRequired
                        label="Price"
                        labelPlacement="outside"
                        placeholder="100"
                        type="number"
                        value={field.value?.toString()}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:wad-of-money-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                      />
                    )}
                  />
                </div>

                <div className="w-full flex flex-row flex-wrap gap-4">
                  <Controller
                    name="category"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Autocomplete
                        required
                        className="w-full"
                        label="Search a category"
                        labelPlacement="outside"
                        placeholder="Monitors category"
                        defaultItems={categories}
                        value={field.value?.toString()}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:box-minimalistic-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                        defaultSelectedKey={
                          product ? product.category.id.toString() : undefined
                        }
                        onSelectionChange={(e) => {
                          field.onChange(
                            categories.find((d) => d.id === Number(e))
                          );
                        }}
                      >
                        {(item) => (
                          <AutocompleteItem key={item.id}>
                            {item.name}
                          </AutocompleteItem>
                        )}
                      </Autocomplete>
                    )}
                  />
                </div>
                <Textarea
                  className="w-full"
                  label="Notes"
                  labelPlacement="outside"
                  placeholder="Adding important notes."
                />

                <div className="flex w-full space-x-4 justify-end pt-4">
                  <Button color="default" variant="shadow" onPress={onClose}>
                    Cancel
                  </Button>
                  <Button
                    type="submit"
                    variant="shadow"
                    color="primary"
                    isLoading={isLoading}
                  >
                    Save changes
                  </Button>
                </div>
              </form>
            </FormProvider>
          )
        )}
      </DrawerContent>
    </Drawer>
  );
}
