"use client";
import { RegisterForm } from "@/components/users/auth/register-form";
import { Card, CardBody } from "@heroui/react";

export default function LogInPage() {
  return (
    <Card className="max-w-5xl w-full h-full my-12 bg-foreground-100 ">
      <CardBody className="justify-center">
        <div className="flex w-full h-full items-center justify-end space-x-4">
          <RegisterForm />
          {/* <div className="bg-blue-800 rounded-xl w-full h-full"></div> */}
          <img
            alt="Login page image"
            src="/login-image.svg"
            className="w-full h-full p-16"
          />
        </div>
      </CardBody>
    </Card>
  );
}
