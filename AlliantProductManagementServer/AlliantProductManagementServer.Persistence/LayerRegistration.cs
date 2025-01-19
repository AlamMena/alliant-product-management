using AlliantProductManagementServer.Domain.Repositories.Core;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Core;
using AlliantProductManagementServer.Persistence.Repositories.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence
{
    public static class LayerRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)),
                ServiceLifetime.Scoped);

            //Inyecciones de dependencias.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
