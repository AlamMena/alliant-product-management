using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AlliantProductManagementServer.Persistence.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Handlers
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
    public class CreateProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        : IRequestHandler<CreateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductCategoryDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<ProductCategory>(request);

            await _productCategoryRepository.AddAsync(category);

            var response = _mapper.Map<ProductCategory, ProductCategoryDto>(category);

            return response;

        }
    }
}
