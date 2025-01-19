using AlliantProductManagementServer.Application.Dtos.Core;
using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using MediatR;

namespace AlliantProductManagementServer.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetAllPaginatedCommand<CustomerDto>, PaginatedResponseDto<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResponseDto<CustomerDto>> Handle(GetAllPaginatedCommand<CustomerDto> request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllPaginatedAsync(request.Page, request.Limit);

            return new PaginatedResponseDto<CustomerDto>
            {
                Count = await _customerRepository.CountAsync(),
                Data = _mapper.Map<IEnumerable<CustomerDto>>(customers)
            };

        }
    }
}
