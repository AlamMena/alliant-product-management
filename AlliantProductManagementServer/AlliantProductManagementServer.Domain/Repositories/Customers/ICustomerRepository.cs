using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetCustomerByIdentificationAsync(string identification);
    }
}
