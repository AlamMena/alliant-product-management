using AlliantProductManagementServer.Application.Features.Customers.Queries;
using AlliantProductManagementServer.Application.Features.Customers.Queries.Reports;
using AlliantProductManagementServer.WebAPI.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliantProductManagementServer.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Customer controller management")]
    [Route("api")]
    public class CustomersReportsController(IMediator mediator) : CoreController(mediator)
    {
        [HttpGet("customers/reports/createdByDate")]
        public async Task<IActionResult> GetReportByDate(GetCustomersCreatedByDateCommand command)
        {
            var customer = await Mediator.Send(command);
            return Ok(customer);
        }

        [HttpGet("customers/reports/acquisitions/quantity")]
        public async Task<IActionResult> GetReportByDate(GetAcquisitionsLastMonthCommand command)
        {
            var customer = await Mediator.Send(command);
            return Ok(customer);
        }
        [HttpGet("customers/reports/acquisitions/balance")]
        public async Task<IActionResult> GetReportByDate(GetAcquisitionsBalanceLastMonthCommand command)
        {
            var customer = await Mediator.Send(command);
            return Ok(customer);
        }

    }
}
