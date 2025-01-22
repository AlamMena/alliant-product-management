using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Persistence.EntitiesConfig.Customers;
using AlliantProductManagementServer.Persistence.EntitiesConfig.Products;
using AlliantProductManagementServer.Persistence.EntitiesConfig.ProductsCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.Contexts
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomersConfig());
            modelBuilder.ApplyConfiguration(new ProductsConfig());
            modelBuilder.ApplyConfiguration(new ProductsCategoriesConfig());

        }
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CustomerProduct> CustomerProducts { get; set; } = null!;
    }
}
