export interface DateReport {
  title: string;
  total: Number;
  data: DateReportData[];
}

export interface DateReportData {
  date: Date;
  value: number;
}
