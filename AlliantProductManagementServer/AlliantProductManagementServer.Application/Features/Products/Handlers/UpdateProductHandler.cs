using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AutoMapper;
using MediatR;
using System.Net;

namespace AlliantProductManagementServer.Application.Features.Products.Handlers
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryDto Category { get; set; } = null!;
    }

    public class UpdateProductHandler(IProductRepository productRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var category = await _productCategoryRepository.GetByIdAsync(product.CategoryId);
            if (category is null)
            {
                throw new DomainException("Category not found", (int)HttpStatusCode.BadRequest);
            }

            await _productRepository.UpdateAsync(product);

            var response = _mapper.Map<Product, ProductDto>(product);

            return response;

        }
    }
}
