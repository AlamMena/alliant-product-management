using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Clients.Handlers
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
    public class CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer);

            var response = _mapper.Map<Customer, CustomerDto>(customer);

            return response;
        }
    }
}
