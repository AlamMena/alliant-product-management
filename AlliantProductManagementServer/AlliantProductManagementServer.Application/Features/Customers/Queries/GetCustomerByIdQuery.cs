using AlliantProductManagementServer.Application.Dtos.Core;
using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Customers.Queries
{
    public class GetCustomerWithProductsCommand : IRequest<CustomerWithProductsDto>
    {
        public int Id { get; set; }
    }
    public class GetCustomerByIdQuery(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetCustomerWithProductsCommand, CustomerWithProductsDto>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CustomerWithProductsDto> Handle(GetCustomerWithProductsCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdWithProductsAsync(request.Id);

            if (customer is null)
            {
                throw new DomainException("Customer not found", (int)HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<Customer, CustomerWithProductsDto>(customer);

            return response;

        }
    }
}
