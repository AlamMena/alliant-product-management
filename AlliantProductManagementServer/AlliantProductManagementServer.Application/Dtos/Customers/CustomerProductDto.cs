using AlliantProductManagementServer.Application.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Dtos.Customers
{
    public class CustomerProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ProductCategoryDto? Category { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
