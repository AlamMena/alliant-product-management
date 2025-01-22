using AlliantProductManagementServer.Domain.Core;
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
        public async Task<Customer?> GetCustomerByIdWithProductsAsync(int id)
        {
            try
            {
                var customer = await _dbContext.Customers
                    .Include(d => d.Products)
                    .ThenInclude(d => d.Product)
                    .FirstOrDefaultAsync(d => d.Id == id);

                return customer;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }
        public async Task<PaginatedResponse<Customer>> GetCustomersByNameAsync(string name, int page, int limit)
        {
            try
            {
                var query = _dbContext.Customers
                    .Where(d => EF.Functions.ILike(d.Name, $"%{name}%"));

                var customers = await query
                    .OrderByDescending(d => d.Id)
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .ToListAsync();

                var customersCount = await query.CountAsync();

                return new PaginatedResponse<Customer>
                {
                    Count = customersCount,
                    Data = customers
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }
        public async Task<Customer?> UpdateCustomerWithProducts(Customer customer)
        {
            try
            {
                var entry = await _dbContext.Customers.Include(d => d.Products).FirstOrDefaultAsync(d => d.Id == customer.Id);

                if (entry is not null)
                {
                    _dbContext.Entry(entry).CurrentValues.SetValues(customer);

                    entry.Products = customer.Products;
                    entry.UpdatedAt = DateTime.UtcNow;

                    await _dbContext.SaveChangesAsync();
                }

                return customer;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }

        public async Task<DateReport> GetCustomersCreatedLastMonth()
        {
            try
            {
                var reports = await _dbContext.Products
                    .GroupBy(d => new { d.CreatedAt })
                    .Select(d => new DateReportData
                    {
                        Date = d.Key.CreatedAt,
                        Value = d.Count(),
                    })
                    .ToListAsync();

                return new DateReport
                {
                    Title = "Customers created this month",
                    Total = reports.Sum(d => d.Value),
                    Data = reports
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }

        public async Task<DateReport> GetCustomersAcquisitionsLastMonth()
        {
            try
            {
                var reports = await _dbContext.CustomerProducts
                    .GroupBy(d => new { CreatedAt = d.CreatedAt.Date })
                    .Select(d => new DateReportData
                    {
                        Date = d.Key.CreatedAt,
                        Value = d.Count(),
                    })
                    .ToListAsync();

                return new DateReport
                {
                    Title = "Acquisitions this month",
                    Total = reports.Sum(d => d.Value),
                    Data = reports
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }

        public async Task<DateReport> GetCustomersAcquisitionsBalanceLastMonth()
        {
            try
            {
                var reports = await _dbContext.CustomerProducts
                    .GroupBy(d => new { d.CreatedAt })
                    .Select(d => new DateReportData
                    {
                        Date = d.Key.CreatedAt,
                        Value = d.Sum(d => d.Quantity * d.Price)
                    })
                    .ToListAsync();

                return new DateReport
                {
                    Title = "Acquisitions balance this month",
                    Total = reports.Sum(d => d.Value),
                    Data = reports
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }
    }

}
