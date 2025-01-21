"use client";
import { useCustomersStore } from "@/stores/customers";
import { getCustomers } from "@/lib/customers/actions";
import { Button, Pagination } from "@heroui/react";
import { redirect, useRouter } from "next/navigation";
import React from "react";

interface TableBottomContentProps {
  page: number;
  pages: number;
  onPageChange: (value: number) => void;
}
export const BottomContent = ({
  page,
  pages,
  onPageChange,
}: TableBottomContentProps) => {
  return React.useMemo(() => {
    return (
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
    );
  }, [page, pages]);
};
