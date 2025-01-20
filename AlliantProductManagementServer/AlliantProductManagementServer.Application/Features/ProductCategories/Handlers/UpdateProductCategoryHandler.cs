using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Domain.Entities.Products;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AlliantProductManagementServer.Persistence.Repositories.Products;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Handlers
{
    public class UpdateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
    public class UpdateProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        : IRequestHandler<UpdateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductCategoryDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<ProductCategory>(request);

            await _productCategoryRepository.UpdateAsync(category);

            var response = _mapper.Map<ProductCategory, ProductCategoryDto>(category);

            return response;

        }
    }
}
