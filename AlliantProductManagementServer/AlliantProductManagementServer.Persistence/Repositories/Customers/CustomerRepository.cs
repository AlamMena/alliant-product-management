using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Core;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.Repositories.Customers
{
    public class CustomerRepository(ApplicationContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository
    {
        private readonly ApplicationContext _dbContext = dbContext;
        public async Task<Customer?> GetCustomerByIdentificationAsync(string identification)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(d => d.Identification == identification);

                return customer;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
