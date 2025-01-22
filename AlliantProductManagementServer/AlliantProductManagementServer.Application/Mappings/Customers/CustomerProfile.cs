using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Application.Features.Customers.Handlers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
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
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerProductDto, CustomerProduct>().ReverseMap()
                .ForMember(d => d.Name, src => src.MapFrom(d => d.Product.Name))
                .ForMember(d => d.Price, src => src.MapFrom(d => d.Product.Price));
            CreateMap<Customer, CustomerWithProductsDto>();


        }
    }
}
