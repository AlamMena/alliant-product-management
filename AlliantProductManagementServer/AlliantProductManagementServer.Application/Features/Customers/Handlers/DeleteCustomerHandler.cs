using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using MediatR;
using System.Net;

namespace AlliantProductManagementServer.Application.Features.Customers.Handlers
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer is null)
            {
                throw new DomainException("Customer not found", (int)HttpStatusCode.NotFound);
            }

            var response = await _customerRepository.DeleteAsync(request.Id);

            return response;
        }
    }
}
