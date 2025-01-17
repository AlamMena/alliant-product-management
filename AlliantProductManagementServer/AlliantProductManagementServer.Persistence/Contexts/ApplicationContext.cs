using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Persistence.EntitiesConfig.Customers;
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
        }
        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
