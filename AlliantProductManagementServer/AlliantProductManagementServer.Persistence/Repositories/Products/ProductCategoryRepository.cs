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
    public class ProductCategoryRepository(ApplicationContext dbContext) : Repository<ProductCategory>(dbContext), IProductCategoryRepository
    {
        private readonly ApplicationContext _dbContext = dbContext;
        public async Task<bool> CategoryHasProducts(int categoryId)
        {
            try
            {
                return await _dbContext.ProductsCategories
                    .Include(d => d.Products)
                    .AnyAsync(d => d.Id == categoryId && d.Products.Any());
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }

        }

        public async Task<PaginatedResponse<ProductCategory>> GetProductsCategoriesFilteredAsync(string search, int page, int limit)
        {
            try
            {
                var query = _dbContext.ProductsCategories
                    .Where(d => EF.Functions.ILike(d.Name, $"%{search}%"));

                var categories = await query
                    .OrderByDescending(d => d.Id)
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .ToListAsync();

                var categoriesCount = await query.CountAsync();

                return new PaginatedResponse<ProductCategory>
                {
                    Count = categoriesCount,
                    Data = categories
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
