using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Core;
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

    public class GetAllProductsQuery(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetPaginatedCommand<ProductDto>, PaginatedResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponse<ProductDto>> Handle(GetPaginatedCommand<ProductDto> request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllPaginatedAsync(request.Page, request.Limit);

            return new PaginatedResponse<ProductDto>
            {
                Count = await _productRepository.CountAsync(),
                Data = _mapper.Map<IEnumerable<ProductDto>>(products)
            };
        }
    }

}
