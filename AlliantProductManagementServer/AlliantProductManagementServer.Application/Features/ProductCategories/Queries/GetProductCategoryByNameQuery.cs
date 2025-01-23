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

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Queries
{

    public class GetProductCategoriesByNameCommand : GetPaginatedCommand<ProductCategoryDto>
    {
        public string Filter { get; set; } = "";
    }
    public class GetProductCategoryByNameQuery(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        : IRequestHandler<GetProductCategoriesByNameCommand, PaginatedResponse<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponse<ProductCategoryDto>> Handle(GetProductCategoriesByNameCommand request, CancellationToken cancellationToken)
        {
            var categories = await _productCategoryRepository.GetProductsCategoriesFilteredAsync(request.Filter, request.Page, request.Limit);
            var response = new PaginatedResponse<ProductCategoryDto>()
            {
                Count = categories.Count,
                Data = _mapper.Map<IEnumerable<ProductCategoryDto>>(categories.Data)

            };
            return response;
        }
    }
}
