using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlliantProductManagementServer.Domain.Entities.Customers;

namespace AlliantProductManagementServer.Persistence.EntitiesConfig.Customers
{
    internal class CustomersConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60);
            builder.Property(x => x.LastName).HasMaxLength(60);
            builder.Property(x => x.Identification).HasMaxLength(30);
            builder.Property(x => x.PhoneNumber).HasMaxLength(30);
            builder.HasMany(x => x.Products).WithMany(x => x.Customers);
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
