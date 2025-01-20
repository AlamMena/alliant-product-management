using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Products.Queries
{
    public class GetProductByIdCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
    public class GetProductByIdQuery(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetProductByIdCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDto> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new DomainException("Product not found", (int)HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<Product, ProductDto>(product);

            return response;

        }
    }
}
