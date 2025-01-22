"use client";
import React, { ReactElement, useEffect } from "react";
import {
  Input,
  Button,
  Textarea,
  Alert,
  useDisclosure,
  Drawer,
  DrawerContent,
  DrawerBody,
  Spinner,
} from "@heroui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { Controller, FormProvider, useForm } from "react-hook-form";
import { Customer, CustomerSchema } from "@/lib/customers/types";
import z from "zod";
import { useRouter } from "next/navigation";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { getCustomerById, saveCustomer } from "@/lib/customers/actions";
import { toast } from "react-toastify";
import { displayToast } from "@/components/toast";
import { useCustomersStore } from "@/stores/customers";
import { CustomerProductsTable } from "./products-table";
import { useCustomerFormStore } from "@/stores/customers/form";

export function CustomerForm() {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);

  const { getCustomers } = useCustomersStore();
  const { setOpen, isOpen, customer } = useCustomerFormStore();

  const defaultValues: Customer = {
    id: undefined,
    name: "",
    lastName: "",
    email: "",
    identification: "",
    phoneNumber: "",
    products: [],
  };
  const form = useForm<z.infer<typeof CustomerSchema>>({
    resolver: zodResolver(CustomerSchema),
    defaultValues,
  });

  useEffect(() => {
    const handleGetCustomer = async () => {
      if (customer?.id) {
        setIsLoading(true);
        const response = await getCustomerById({ id: customer?.id ?? 0 });
        form.reset(response);
        setIsLoading(false);
      } else {
        form.reset(defaultValues);
      }
    };

    handleGetCustomer();
  }, [customer]);

  const onSubmit = async (values: z.infer<typeof CustomerSchema>) => {
    setIsLoading(true);
    const response = await saveCustomer(values as Customer);
    setIsLoading(false);
    if (response.message) {
      displayToast({
        title: "Error saving the customer",
        description: response.message,
        type: "error",
      });
      return;
    }
    setOpen(false);
    displayToast({
      title: "Customer saved",
      description: "The customer has been saved.",
      type: "success",
    });
    await getCustomers({ page: 1, limit: 5 });
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
                  <span className=" text-2xl">Customer form</span>
                  <span className=" text-sm text-foreground-400 ">
                    Fill the required fields and start managing your client 📝
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
                        placeholder="Alam"
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
                  <Controller
                    name="lastName"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        label="Last Name"
                        labelPlacement="outside"
                        placeholder="Mena Beato"
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
                <div className="flex w-full space-x-4">
                  <Controller
                    name="identification"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        label="Identification"
                        labelPlacement="outside"
                        placeholder="000-0000000-0"
                        value={field.value}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:card-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                      />
                    )}
                  />
                </div>
                <div className="flex w-full space-x-4">
                  <Controller
                    name="email"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        label="Email"
                        labelPlacement="outside"
                        placeholder="Amenabeato@gmail.com"
                        value={field.value ?? ""}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:letter-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                      />
                    )}
                  />
                  <Controller
                    name="phoneNumber"
                    control={form.control}
                    render={({ field, fieldState }) => (
                      <Input
                        label="Phone number"
                        labelPlacement="outside"
                        placeholder="+1 000-000-0000"
                        value={field.value}
                        onValueChange={field.onChange}
                        errorMessage={fieldState.error?.message}
                        isInvalid={!!fieldState.error}
                        startContent={
                          <Icon
                            icon="solar:card-outline"
                            className="text-foreground-400"
                            width="24"
                            height="24"
                          />
                        }
                      />
                    )}
                  />
                </div>
                <Textarea
                  className="w-full"
                  label="Notes"
                  placeholder="Adding important notes."
                />
                {customer?.id && <CustomerProductsTable />}

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
