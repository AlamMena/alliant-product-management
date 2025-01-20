using AlliantProductManagementServer.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Dtos.Customers
{
    public class CustomerWithProductsDto : CustomerDto
    {
        public IEnumerable<CustomerProductDto> Products { get; set; } = [];
    }
}
