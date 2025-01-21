"use client";
import { Button } from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";

export default function CustomersToolBar() {
  return (
    <div className="w-full flex items-center space-x-4">
      <span className="text-xl">Customers</span>
      <Button
        size="sm"
        isIconOnly
        startContent={
          <Icon icon="solar:magnifer-outline" width={16} height={16} />
        }
      />
      <Button
        size="sm"
        isIconOnly
        startContent={
          <Icon icon="solar:file-download-outline" width={16} height={16} />
        }
      />
      <Button
        size="sm"
        isIconOnly
        color="primary"
        startContent={
          <Icon icon="solar:add-circle-outline" width={16} height={16} />
        }
      />
    </div>
  );
}
