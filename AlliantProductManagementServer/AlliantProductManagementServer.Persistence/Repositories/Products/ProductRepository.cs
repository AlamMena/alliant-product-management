using AlliantProductManagementServer.Domain.Core;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.Repositories.Products
{
    public class ProductRepository(ApplicationContext dbContext) : Repository<Product>(dbContext), IProductRepository
    {
        private readonly ApplicationContext _dbContext = dbContext;
        public async Task<PaginatedResponse<Product>> GetProductsFilteredAsync(string search, int page, int limit)
        {
            try
            {
                var query = _dbContext.Products
                    .Where(d => EF.Functions.ILike(d.Name, $"%{search}%"));

                var products = await query
                    .OrderByDescending(d => d.Id)
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .ToListAsync();

                var customersCount = await query.CountAsync();

                return new PaginatedResponse<Product>
                {
                    Count = customersCount,
                    Data = products
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
