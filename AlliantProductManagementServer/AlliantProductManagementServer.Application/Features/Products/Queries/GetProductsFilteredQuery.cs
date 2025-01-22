using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Core;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Products.Queries
{

    public class GetProductsFilteredCommand : GetPaginatedCommand<ProductDto>
    {
        public string Filter { get; set; } = "";
    }
    public class GetProductsFilteredQuery(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetProductsFilteredCommand, PaginatedResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponse<ProductDto>> Handle(GetProductsFilteredCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsFilteredAsync(request.Filter, request.Page, request.Limit);
            var response = new PaginatedResponse<ProductDto>()
            {
                Count = products.Count,
                Data = _mapper.Map<IEnumerable<ProductDto>>(products.Data)

            };
            return response;
        }
    }
}
