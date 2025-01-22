using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Clients.Handlers
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Identification { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        public IEnumerable<CustomerProductDto> Products { get; set; } = [];
    }
    public class CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            var customerWithSameIdentification = await _customerRepository.GetCustomerByIdentificationAsync(request.Identification);
            if (customerWithSameIdentification != null)
            {
                throw new DomainException("The identification number is already registered", (int)HttpStatusCode.Conflict);
            }

            await _customerRepository.AddAsync(customer);

            var response = _mapper.Map<Customer, CustomerDto>(customer);

            return response;
        }
    }
}
