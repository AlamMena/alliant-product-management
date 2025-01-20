using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Customers.Handlers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AlliantProductManagementServer.Domain.Repositories.Products;
using AlliantProductManagementServer.Persistence.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Products.Handlers
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                throw new DomainException("Product not found", (int)HttpStatusCode.NotFound);
            }

            var response = await _productRepository.DeleteAsync(request.Id);

            return response;
        }
    }
}
