using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Core;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Customers.Queries.Reports
{

    public class GetCustomersCreatedByDateCommand : IRequest<DateReport>
    {
        public string Name { get; set; } = "";
    }
    public class GetCustomersCreatedByDate(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetCustomersCreatedByDateCommand, DateReport>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<DateReport> Handle(GetCustomersCreatedByDateCommand request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomersCreatedLastMonth();
        }
    }
}
