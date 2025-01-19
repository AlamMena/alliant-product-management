using AlliantProductManagementServer.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlliantProductManagementServer.Domain.Entities.Products;

namespace AlliantProductManagementServer.Persistence.EntitiesConfig.Products
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60);
            builder.Property(x => x.Price);
            builder.HasOne(x => x.Category).WithMany(x => x.Products);
            builder.HasMany(x => x.Customers).WithMany(x => x.Products);
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
