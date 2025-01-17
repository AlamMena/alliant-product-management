using AlliantProductManagementServer.Domain.Entities.Core;

namespace AlliantProductManagementServer.Domain.Entities.Customers
{
    public class Customer : CoreEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
