using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.ProductCategories.Handlers
{
    public class DeleteProductCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCategoryHandler(IProductCategoryRepository productCategoryRepository) : IRequestHandler<DeleteProductCategoryCommand, int>
    {
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        public async Task<int> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _productCategoryRepository.GetByIdAsync(request.Id);
            if (category is null)
            {
                throw new DomainException("Category not found.", (int)HttpStatusCode.NotFound);
            }
            var categoryHasProducts = await _productCategoryRepository.CategoryHasProducts(request.Id);
            if (categoryHasProducts)
            {
                throw new DomainException("Category has products and can't be removed.", (int)HttpStatusCode.Conflict);
            }

            var response = await _productCategoryRepository.DeleteAsync(request.Id);

            return response;
        }
    }
}
