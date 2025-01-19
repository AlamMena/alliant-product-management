using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.WebAPI.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliantProductManagementServer.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Customer controller management")]
    [Route("api")]
    public class CustomerController(IMediator mediator) : CoreController(mediator)
    {
        [HttpPost("customer")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
        {
            var customer = await Mediator.Send(command);
            return Created($"/customer/{customer.Id}", customer);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPaginatedCommand<CustomerDto> command)
        {
            var customers = await Mediator.Send(command);
            return Ok(customers);


        }
    }
}
