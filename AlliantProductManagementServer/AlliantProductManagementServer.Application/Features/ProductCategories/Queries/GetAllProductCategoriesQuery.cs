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

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Queries
{
    public class GetAllProductCategoriesQuery(IProductCategoryRepository productCategoryRepository, IMapper mapper)
      : IRequestHandler<GetPaginatedCommand<ProductCategoryDto>, PaginatedResponse<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponse<ProductCategoryDto>> Handle(GetPaginatedCommand<ProductCategoryDto> request, CancellationToken cancellationToken)
        {
            var categories = await _productCategoryRepository.GetAllPaginatedAsync(request.Page, request.Limit);

            return new PaginatedResponse<ProductCategoryDto>
            {
                Count = await _productCategoryRepository.CountAsync(),
                Data = _mapper.Map<IEnumerable<ProductCategoryDto>>(categories)
            };
        }
    }

}
