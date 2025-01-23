"use client";
import { Button, Input, Link } from "@heroui/react";
import React, { useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import z from "zod";
import { redirect } from "next/navigation";
import { RegisterSchema } from "@/lib/users/types";
import { logIn, register } from "@/lib/users/actions";

export function RegisterForm() {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [errorMessage, setErrorMessage] = useState<string>();

  const form = useForm<z.infer<typeof RegisterSchema>>({
    resolver: zodResolver(RegisterSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });
  console.log("env", process.env.API_URL);
  const onSubmit = async (values: z.infer<typeof RegisterSchema>) => {
    setIsLoading(true);

    const response = await register({
      username: values.username,
      email: values.email,
      password: values.password,
    });

    if (response.message) {
      setErrorMessage(response.message);
    }

    if (!response.message) {
      redirect("/customers");
    }

    setIsLoading(false);
  };

  return (
    <div className="flex flex-col justify-center w-full h-full max-w-sm rounded-xl p-8 bg-white">
      <h1 className="text-3xl mb-8 text-center text-primary">
        Alliant Customers Management
      </h1>
      <form
        className="flex flex-col gap-4 "
        onSubmit={form.handleSubmit(onSubmit)}
      >
        <Controller
          name="username"
          control={form.control}
          render={({ field, fieldState }) => (
            <Input
              isRequired
              label="Username"
              labelPlacement="outside"
              placeholder="insert your username "
              variant="bordered"
              value={field.value}
              onValueChange={field.onChange}
              errorMessage={fieldState.error?.message}
              isInvalid={!!fieldState.error}
            />
          )}
        />
        <Controller
          name="email"
          control={form.control}
          render={({ field, fieldState }) => (
            <Input
              isRequired
              label="Email"
              labelPlacement="outside"
              placeholder="insert your email"
              type="email"
              variant="bordered"
              value={field.value}
              onValueChange={field.onChange}
              errorMessage={fieldState.error?.message}
              isInvalid={!!fieldState.error}
            />
          )}
        />
        <Controller
          name="password"
          control={form.control}
          render={({ field, fieldState }) => (
            <Input
              isRequired
              label="Password"
              labelPlacement="outside"
              placeholder="insert your password "
              type={"password"}
              variant="bordered"
              value={field.value}
              onValueChange={field.onChange}
              errorMessage={fieldState.error?.message}
              isInvalid={!!fieldState.error}
            />
          )}
        />
        <Button
          color="primary"
          type="submit"
          variant="shadow"
          isLoading={isLoading}
          isDisabled={isLoading}
        >
          Register
        </Button>
        <p className="text-center my-4 text-small">
          Do you already have an account?{" "}
          <Link href="/login" size="sm">
            Log in here!
          </Link>
        </p>
        {errorMessage && (
          <span className="text-danger-400 text-sm inline-block text-center">
            {errorMessage}
          </span>
        )}
      </form>
    </div>
  );
}
