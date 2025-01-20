using AlliantProductManagementServer.Application.Dtos.Core;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Core.Commands;
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
        : IRequestHandler<GetAllPaginatedCommand<ProductDto>, PaginatedResponseDto<ProductDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponseDto<ProductDto>> Handle(GetAllPaginatedCommand<ProductDto> request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllPaginatedAsync(request.Page, request.Limit);

            return new PaginatedResponseDto<ProductDto>
            {
                Count = await _productRepository.CountAsync(),
                Data = _mapper.Map<IEnumerable<ProductDto>>(products)
            };
        }
    }

}
