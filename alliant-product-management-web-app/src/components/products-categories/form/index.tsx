"use client";
import React, { useEffect } from "react";
import {
  Input,
  Button,
  Textarea,
  Drawer,
  DrawerContent,
  Spinner,
} from "@heroui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { Controller, FormProvider, useForm } from "react-hook-form";
import z from "zod";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { displayToast } from "@/components/toast";
import {
  CategorySchema,
  ProductCategory,
} from "@/lib/products-categories/types";
import { useProductCategoriesFormStore } from "@/stores/products-categories/form";
import { useProductCategoriesStore } from "@/stores/products-categories";
import {
  getCategoryById,
  saveCategory,
} from "@/lib/products-categories/actions";

export function CategoryForm() {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const { getCategories } = useProductCategoriesStore();
  const { setOpen, isOpen, category } = useProductCategoriesFormStore();

  const defaultValues = {
    id: undefined,
    name: "",
    price: 0,
  };
  const form = useForm<z.infer<typeof CategorySchema>>({
    resolver: zodResolver(CategorySchema),
    defaultValues,
  });

  useEffect(() => {
    const handleGetCategory = async () => {
      if (category?.id) {
        setIsLoading(true);
        const response = await getCategoryById({ id: category?.id ?? 0 });
        form.reset(response);
        setIsLoading(false);
      } else {
        form.reset(defaultValues);
      }
    };
    handleGetCategory();
  }, [category]);

  const onSubmit = async (values: z.infer<typeof CategorySchema>) => {
    setIsLoading(true);
    const response = await saveCategory(values as ProductCategory);
    setIsLoading(false);
    if (response.message) {
      displayToast({
        title: "Error saving the category",
        description: response.message,
        type: "error",
      });
      return;
    }
    setOpen(false);
    displayToast({
      title: "Category saved",
      description: "The category has been saved.",
      type: "success",
    });
    await getCategories({ page: 1, limit: 5 });
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
                  <span className=" text-2xl">Category form</span>
                  <span className=" text-sm text-foreground-400 ">
                    Fill the required fields and start managing your category 📝
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
                        placeholder="Category name"
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
                <div className="flex w-full space-x-4 items-center">
                  <Controller
                    name="description"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Textarea
                        value={field.value}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        className="w-full"
                        label="Notes"
                        labelPlacement="outside"
                        placeholder="Adding important notes."
                      />
                    )}
                  />
                </div>

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
