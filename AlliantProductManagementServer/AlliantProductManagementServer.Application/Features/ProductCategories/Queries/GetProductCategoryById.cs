using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Products.Queries;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Queries
{
    public class GetProductCategoryByIdCommand : IRequest<ProductCategoryDto>
    {
        public int Id { get; set; }
    }
    public class GetProductCategoryByIdQuery(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        : IRequestHandler<GetProductCategoryByIdCommand, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductCategoryDto> Handle(GetProductCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category = await _productCategoryRepository.GetByIdAsync(request.Id);

            if (category is null)
            {
                throw new DomainException("Category not found", (int)HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<ProductCategory, ProductCategoryDto>(category);

            return response;

        }
    }
}
