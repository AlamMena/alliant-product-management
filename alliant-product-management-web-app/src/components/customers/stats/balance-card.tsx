"use client";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import { Button, Card, CardBody, CardFooter, CardHeader } from "@heroui/react";
import { ExpensesLineChart } from "./line-chart";

export interface BalanceCardProps {
  balance: number;
  title: string;
  comparePercentage: number;
  compareTitle: string;
}
export function BalanceCard(props: BalanceCardProps) {
  const { balance, title, comparePercentage, compareTitle } = props;
  return (
    <Card className="w-full h-full">
      <CardHeader className="flex flex-col space-y-2 items-start p-6">
        {/* <Button
          isIconOnly
          variant="shadow"
          className="rounded-full p-2 border-1 bg-transparent"
        >
          <Icon
            icon={`${
              balance > 0 ? "solar:card-recive-bold" : "solar:card-send-bold"
            }`}
            width="32"
            height="32"
            className={`${
              balance > 0 ? "text-primary" : "text-danger-400"
            } text-xs`}
          />
        </Button> */}
        <span className="text-lg">{title}</span>
        <span className=" font-bold text-2xl">$123,200.12</span>
      </CardHeader>
      <CardBody className="justify-center h-full ">
        <ExpensesLineChart />
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
