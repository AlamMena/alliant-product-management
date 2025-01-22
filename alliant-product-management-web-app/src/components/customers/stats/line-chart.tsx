"use client";
import { ApexOptions } from "apexcharts";
import React, { useEffect, useState } from "react";
import ApexCharts from "@/lib/charts";
import { getCustomersCreatedByDate } from "@/lib/customers/actions";
import { DateReport, DateReportData } from "@/lib/common/date-report";

export function LineChart({ data }: { data?: DateReportData[] }) {
  const series = [
    {
      name: "Expenses",
      data: data?.map((item) => item.value) ?? [],
    },
  ];
  const options: ApexOptions = {
    chart: {
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
    },
    legend: {
      show: false,
    },
    dataLabels: {
      enabled: false,
    },
    // tooltip: {
    //   enabled: 1,
    // },
    xaxis: {
      //   : false,
      categories: data?.map((d) => d.date) ?? [],
      labels: { show: false, style: { colors: "grey" } },
      axisTicks: { show: false },
    },
    yaxis: {
      show: false,
      labels: { show: false, style: { colors: "grey" } },
    },
    grid: {
      show: false,
    },
    stroke: {
      curve: "smooth",
      lineCap: "round",
      width: 2.4,
    },
  };

  return (
    <ApexCharts
      id="expenses-line-chart"
      options={options}
      series={series}
      type="area"
      width={"100%"}
      height={"110"}
    />
  );
}
