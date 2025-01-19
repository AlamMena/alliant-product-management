using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Dtos.Core
{
    public class PaginatedResponseDto<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; } = [];
    }
}
