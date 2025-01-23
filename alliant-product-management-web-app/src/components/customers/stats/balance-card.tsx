"use client";
import { Card, CardBody, CardHeader } from "@heroui/react";
import { LineChart } from "./line-chart";
import { DateReport } from "@/lib/common/date-report";

export interface BalanceCardProps {
  report?: DateReport;
}
export function BalanceCard(props: BalanceCardProps) {
  const { report } = props;
  return (
    <Card className="w-full h-full">
      <CardHeader className="flex flex-col space-y-2 items-start p-6">
        <span className="text-lg">{report?.title ?? "No data found"}</span>
        <span className=" font-bold text-2xl">
          {report?.total.toString() ?? ""}
        </span>
      </CardHeader>
      <CardBody className="justify-center h-full ">
        <LineChart data={report?.data} />
      </CardBody>
    </Card>
  );
}
