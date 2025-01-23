export interface DateReport {
  title: string;
  total: number;
  data: DateReportData[];
}

export interface DateReportData {
  date: Date;
  value: number;
}
