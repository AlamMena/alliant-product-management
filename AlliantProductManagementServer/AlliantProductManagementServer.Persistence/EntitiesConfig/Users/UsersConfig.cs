using AlliantProductManagementServer.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlliantProductManagementServer.Domain.Entities.Users;

namespace AlliantProductManagementServer.Persistence.EntitiesConfig.Users
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(60);
            builder.Property(x => x.Email).HasMaxLength(60);
            builder.Property(x => x.Password).HasMaxLength(20);
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
