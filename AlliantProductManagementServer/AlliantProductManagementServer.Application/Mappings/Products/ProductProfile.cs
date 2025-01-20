using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Products.Handlers;
using AlliantProductManagementServer.Domain.Entities.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Mappings.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
