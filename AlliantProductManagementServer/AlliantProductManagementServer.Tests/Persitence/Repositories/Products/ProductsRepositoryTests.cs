using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Customers;
using AlliantProductManagementServer.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Tests.Persitence.Repositories.Products
{
    public class ProductsRepositoryTests
    {
        [Fact]
        public async Task TestProductCreation()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            await using var context = new ApplicationContext(options);

            var categoryRepository = new ProductCategoryRepository(context);
            var productRepository = new ProductRepository(context);

            var category = await categoryRepository.AddAsync(new ProductCategory
            {
                Name = "Technolgy",
                Description = "Category for tech articles"
            });

            var product = await productRepository.AddAsync(new Product
            {
                Name = "Custom tech article",
                Price = 100,
                Category = category
            });

            var entityCount = await productRepository.CountAsync();
            Assert.Equal(1, entityCount);
        }
    }
}
