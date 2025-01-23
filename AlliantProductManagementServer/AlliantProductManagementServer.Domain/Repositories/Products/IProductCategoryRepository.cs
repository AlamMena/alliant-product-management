using AlliantProductManagementServer.Domain.Core;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Repositories.Products
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<bool> CategoryHasProducts(int categoryId);
        Task<PaginatedResponse<ProductCategory>> GetProductsCategoriesFilteredAsync(string search, int page, int limit);
    }
}
