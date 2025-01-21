import { Alert } from "@heroui/react";
import { toast } from "react-toastify";

interface DisplayToastProps {
  title: string;
  description: string;
  type: "error" | "success" | "warning";
}
export function displayToast({ title, description, type }: DisplayToastProps) {
  toast(
    <div className="flex flex-col">
      <span className="text-sm">{title}</span>
      <span className="text-xs">{description}</span>
    </div>,
    {
      closeButton: false,
      className: "p-4",
      type: type,
      icon: undefined,
    }
  );
}
