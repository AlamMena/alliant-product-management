using AlliantProductManagementServer.Application.Security;
using AlliantProductManagementServer.Application.Utils;
using AlliantProductManagementServer.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application
{
    public static class LayerRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AutoMapper to map between objects
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register MediatR for implementing the mediator pattern
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));

            services.AddScoped<IAuthHandler, AuthHandler>();

            services.AddPersistenceLayer(configuration);
        }
    }
}
