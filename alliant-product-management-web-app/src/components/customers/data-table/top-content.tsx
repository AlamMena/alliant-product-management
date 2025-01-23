import { Button, Input } from "@heroui/react";
import React from "react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { useCustomersStore } from "@/stores/customers";
import { debounce } from "lodash";
import { useCustomerFormStore } from "@/stores/customers/form";
import { HandleDownloadTxt } from "@/lib/core";
import { Customer } from "@/lib/customers/types";

export const TopContent = () => {
  const [filterValue, setFilterValue] = React.useState("");
  const { getCustomers, customers } = useCustomersStore();
  const { setOpen } = useCustomerFormStore();

  // Debounce the API call
  const debouncedSearch = React.useMemo(
    () =>
      debounce(async (value: string) => {
        await getCustomers({ page: 1, limit: 5, search: value });
      }, 300), // 300ms debounce delay
    [getCustomers]
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

  // Cleanup the debounce function on component unmount
  React.useEffect(() => {
    return () => {
      debouncedSearch.cancel();
    };
  }, [debouncedSearch]);

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
            value={filterValue}
            // onClear={() => onClear()}
            onValueChange={(e) => onSearchChange(e)}
          />
          <Button
            size="sm"
            isIconOnly
            variant="shadow"
            onPress={() => onSearchChange(filterValue)}
            startContent={
              <Icon icon="solar:magnifer-outline" width={16} height={16} />
            }
          />
          <Button
            size="sm"
            isIconOnly
            onPress={() =>
              HandleDownloadTxt<Customer>("customers", customers.data)
            }
            variant="shadow"
            startContent={
              <Icon icon="solar:file-download-outline" width={16} height={16} />
            }
          />

          <Button
            size="sm"
            isIconOnly
            onPress={() => setOpen(true, undefined)}
            variant="shadow"
            color="primary"
            startContent={
              <Icon icon="solar:add-circle-outline" width={16} height={16} />
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
  }, [filterValue, onSearchChange, setOpen]);
};
