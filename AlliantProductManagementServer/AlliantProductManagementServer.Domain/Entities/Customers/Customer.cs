using AlliantProductManagementServer.Domain.Entities.Core;
using AlliantProductManagementServer.Domain.Entities.Products;

namespace AlliantProductManagementServer.Domain.Entities.Customers
{
    public class Customer : CoreEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = [];
    }
}
