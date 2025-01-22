using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Core;
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
    public class GetCustomersByNameCommand : GetPaginatedCommand<CustomerDto>
    {
        public string Name { get; set; } = "";
    }
    public class GetCustomersByNameQuery(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetCustomersByNameCommand, PaginatedResponse<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponse<CustomerDto>> Handle(GetCustomersByNameCommand request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersByNameAsync(request.Name, request.Page, request.Limit);
            var response = new PaginatedResponse<CustomerDto>()
            {
                Count = customers.Count,
                Data = _mapper.Map<IEnumerable<CustomerDto>>(customers.Data)

            };
            return response;
        }
    }
}
