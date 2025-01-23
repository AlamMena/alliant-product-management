using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AlliantProductManagementServer.Persistence.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Products.Handlers
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public ProductCategoryDto Category { get; set; } = null!;
    }

    public class CreateProductHandler(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IMapper mapper)
        : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var category = await _productCategoryRepository.GetByIdAsync(product.CategoryId);
            if (category is null)
            {
                throw new DomainException("Category not found", (int)HttpStatusCode.BadRequest);
            }

            await _productRepository.AddAsync(product);

            var response = _mapper.Map<Product, ProductDto>(product);

            return response;

        }
    }
}
