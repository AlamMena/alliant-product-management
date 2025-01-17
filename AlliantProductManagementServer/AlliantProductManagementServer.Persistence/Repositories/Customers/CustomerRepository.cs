using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Repositories.Core;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.Repositories.Customers
{
    public class CustomerRepository(ApplicationContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository
    {
    }
}
