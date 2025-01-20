using AlliantProductManagementServer.Domain.Entities.Core;
using AlliantProductManagementServer.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Entities.Products
{
    public class Product : CoreEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;
        public ICollection<CustomerProduct> Customers { get; set; } = [];
    }
}
