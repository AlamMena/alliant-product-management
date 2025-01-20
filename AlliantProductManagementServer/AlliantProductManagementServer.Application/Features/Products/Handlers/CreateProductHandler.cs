using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Products.Handlers
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product);

            var response = _mapper.Map<Product, ProductDto>(product);

            return response;

        }
    }
}
