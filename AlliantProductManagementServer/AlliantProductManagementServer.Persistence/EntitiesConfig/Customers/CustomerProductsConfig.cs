using AlliantProductManagementServer.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.EntitiesConfig.Customers
{
    public class CustomerProductsConfig : IEntityTypeConfiguration<CustomerProduct>
    {


        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.HasQueryFilter(d => !d.IsDeleted );
            builder.HasQueryFilter(d => !d.Product.IsDeleted);
        }
    }
}
