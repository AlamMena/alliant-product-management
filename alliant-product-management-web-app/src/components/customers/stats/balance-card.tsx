"use client";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { Button, Card, CardBody, CardFooter, CardHeader } from "@heroui/react";
import { LineChart } from "./line-chart";
import { useEffect, useState } from "react";
import { DateReport } from "@/lib/common/date-report";
import { getCustomersCreatedByDate } from "@/lib/customers/actions";

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
      {/* <CardFooter className="space-x-4">
        <div className="flex flex-col">
          <span className="text-2xl">{balance}</span>

          <span
            className={`${
              balance > 0 ? "text-primary" : "text-danger-400"
            } text-xs`}
          >
            +{comparePercentage}%
            <span className="text-foreground-400 text-xs">
              {" " + compareTitle}
            </span>
          </span>
        </div>
      </CardFooter> */}
    </Card>
  );
}
