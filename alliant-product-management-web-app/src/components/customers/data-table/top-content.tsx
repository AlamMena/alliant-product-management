import {
  Button,
  Dropdown,
  DropdownMenu,
  DropdownTrigger,
  Input,
} from "@heroui/react";
import React from "react";
import { useRouter } from "next/navigation";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import CustomersToolBar from "../toolbar";
import { CustomerForm } from "../form";

export const TopContent = () => {
  const router = useRouter();

  const [filterValue, setFilterValue] = React.useState("");
  const [rowsPerPage, setRowsPerPage] = React.useState(5);

  const onSearchChange = React.useCallback((value?: string) => {
    if (value) {
      setFilterValue(value);
    } else {
      setFilterValue("");
    }
    router.push(`/clients?page=1&search=${value}`);
  }, []);

  const onClear = React.useCallback(() => {
    setFilterValue("");
    router.push(`/clients?page=1&search=${""}`);
  }, []);

  const onRowsPerPageChange = React.useCallback(
    (e: React.ChangeEvent<HTMLSelectElement>) => {
      setRowsPerPage(Number(e.target.value));
    },
    []
  );

  function debounce(func: (...args: any[]) => void, delay: number) {
    let timer: NodeJS.Timeout;
    return (...args: any[]) => {
      clearTimeout(timer);
      timer = setTimeout(() => {
        func(...args);
      }, delay);
    };
  }

  const debouncedNavigate = React.useCallback(
    debounce((value: string) => {
      if (value.trim() !== "") {
        router.push("/sim");
      }
    }, 300),
    []
  );

  return React.useMemo(() => {
    return (
      <div className="flex flex-col gap-4">
        <div className="flex space-x-2 items-center">
          <span className="text-xl">Customers</span>
          <Icon icon="flat-color-icons:reading-ebook" width="24" height="24" />
        </div>

        <div className="flex gap-3 items-center">
          <Input
            variant="faded"
            isClearable
            className="w-full sm:max-w-[44%]"
            placeholder="Search by name..."
            // startContent={<SearchIcon />}
            value={filterValue}
            onClear={() => onClear()}
            onValueChange={onSearchChange}
          />
          <Button
            size="sm"
            isIconOnly
            variant="shadow"
            startContent={
              <Icon icon="solar:magnifer-outline" width={16} height={16} />
            }
          />
          <Button
            size="sm"
            isIconOnly
            variant="shadow"
            startContent={
              <Icon icon="solar:file-download-outline" width={16} height={16} />
            }
          />

          <CustomerForm
            triggerContent={
              <Button
                size="sm"
                isIconOnly
                variant="shadow"
                color="primary"
                startContent={
                  <Icon
                    icon="solar:add-circle-outline"
                    width={16}
                    height={16}
                  />
                }
              />
            }
          />
        </div>
        <div className="flex justify-between items-center">
          <span className="text-default-400 text-small">
            {/* Total {totalData} clients */}
          </span>
        </div>
      </div>
    );
  }, [filterValue, onSearchChange, onRowsPerPageChange]);
};
