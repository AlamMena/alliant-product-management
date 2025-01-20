using AlliantProductManagementServer.Application.Dtos.Customers;
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

namespace AlliantProductManagementServer.Application.Features.Customers.Handlers
{
    public class UpdateCustomerCommand : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public IEnumerable<CustomerProductDto> Products { get; set; } = [];
    }
    public class UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            var customerWithSameIdentification = await _customerRepository.GetCustomerByIdentificationAsync(request.Identification);
            if (customerWithSameIdentification != null && customerWithSameIdentification.Id != request.Id)
            {
                throw new DomainException("The identification number is already registered", (int)HttpStatusCode.Conflict);
            }

            await _customerRepository.UpdateCustomerWithProducts(customer);

            var response = _mapper.Map<Customer, CustomerDto>(customer);

            return response;
        }
    }
}
