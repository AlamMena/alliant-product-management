"use client";
import { Breadcrumbs, BreadcrumbItem } from "@heroui/react";

export interface BreadcrumbProp {
  title: string;
  href?: string;
}
export function Bredacrumb({ items }: { items: BreadcrumbProp[] }) {
  return (
    <Breadcrumbs>
      {items.map((item) => {
        return <BreadcrumbItem key={item.title}>{item.title}</BreadcrumbItem>;
      })}
    </Breadcrumbs>
  );
}
