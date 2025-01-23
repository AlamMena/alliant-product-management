using AlliantProductManagementServer.Domain.Core;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Repositories.Core;

namespace AlliantProductManagementServer.Domain.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<PaginatedResponse<Product>> GetProductsFilteredAsync(string search, int page, int limit);
        Task<bool> ProductHasCustomers(int productId);
    }
}
