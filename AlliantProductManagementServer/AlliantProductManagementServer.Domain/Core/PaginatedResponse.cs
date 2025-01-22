using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Core
{
    public class PaginatedResponse<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; } = [];
    }
}
