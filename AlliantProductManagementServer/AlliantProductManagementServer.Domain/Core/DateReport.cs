using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Core
{
    public class DateReport
    {
        public decimal Total { get; set; }
        public string Title { get; set; } = null!;
        public IEnumerable<DateReportData> Data { get; set; } = [];
    }

    public class DateReportData
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
