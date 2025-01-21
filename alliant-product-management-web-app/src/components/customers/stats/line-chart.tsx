"use client";
import { ApexOptions } from "apexcharts";
import React from "react";
import ApexCharts from "@/lib/charts";
const dataCharts = [
  {
    label: "Balance",
    data: [
      { date: "0001-01-01T00:00:00", value: 40 },
      { date: "2023-02-19T17:09:45", value: 20 },
      { date: "2023-02-20T12:00:50", value: 22 },
      { date: "2023-02-21T01:03:07", value: 38 },
      { date: "2023-02-22T14:27:08", value: 19 },
    ],
    total: 4234.34,
    increasePercentage: 50,
  },
];
export function ExpensesLineChart() {
  const series = [
    {
      name: "LineChart",
      data: dataCharts[0].data.map((item) => item.value),
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
    xaxis: {
      //   : false,
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
      width={"95%"}
      height={"110"}
    />
  );
}
