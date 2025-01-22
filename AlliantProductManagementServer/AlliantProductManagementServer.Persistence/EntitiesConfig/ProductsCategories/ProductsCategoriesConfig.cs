using AlliantProductManagementServer.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.EntitiesConfig.ProductsCategories
{
    public class ProductsCategoriesConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(60);
            //builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
