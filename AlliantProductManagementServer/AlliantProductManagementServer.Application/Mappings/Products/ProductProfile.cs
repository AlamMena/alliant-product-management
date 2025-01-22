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
            CreateMap<CreateProductCommand, Product>()
                .ForMember(d => d.CategoryId, d => d.MapFrom(d => d.Category.Id))
                .ForMember(d => d.Category, d => d.Ignore());

            CreateMap<UpdateProductCommand, Product>()
               .ForMember(d => d.CategoryId, d => d.MapFrom(d => d.Category.Id))
               .ForMember(d => d.Category, d => d.Ignore());

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();




        }
    }
}
