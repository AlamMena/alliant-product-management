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
    public class GetAcquisitionsBalanceLastMonthCommand : IRequest<DateReport>
    {
        public string Name { get; set; } = "";
    }
    public class GetAcquisitionsBalanceLastMonth(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetAcquisitionsBalanceLastMonthCommand, DateReport>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<DateReport> Handle(GetAcquisitionsBalanceLastMonthCommand request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomersAcquisitionsBalanceLastMonth();
        }
    }
}
