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

    public class GetAcquisitionsLastMonthCommand : IRequest<DateReport>
    {
        public string Name { get; set; } = "";
    }
    public class GetAcquisitionsLastMonth(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetAcquisitionsLastMonthCommand, DateReport>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<DateReport> Handle(GetAcquisitionsLastMonthCommand request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomersAcquisitionsLastMonth();
        }
    }

}
