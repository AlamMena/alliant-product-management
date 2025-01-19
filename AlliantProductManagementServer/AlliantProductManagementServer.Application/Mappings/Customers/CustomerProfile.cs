using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Mappings.Customers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
