"use client";
import { Pagination } from "@heroui/react";
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
  }, [page, pages, onPageChange]);
};
