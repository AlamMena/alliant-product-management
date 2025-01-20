using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Application.Features.Customers.Handlers;
using AlliantProductManagementServer.Application.Features.Customers.Queries;
using AlliantProductManagementServer.Application.Features.Products.Handlers;
using AlliantProductManagementServer.Application.Features.Products.Queries;
using AlliantProductManagementServer.WebAPI.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliantProductManagementServer.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Products controller management")]
    [Route("api")]
    public class ProductController(IMediator mediator) : CoreController(mediator)
    {
        [HttpPost("/product")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand command)
        {
            var product = await Mediator.Send(command);
            return Created($"/product/{product.Id}", product);
        }

        [HttpGet("/products")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPaginatedCommand<ProductDto> command)
        {
            var products = await Mediator.Send(command);
            return Ok(products);
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            var product = await Mediator.Send(command);
            return Ok(product);
        }

        [HttpDelete("product/{Id}")]
        public async Task<IActionResult> DelteAsync(DeleteProductCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("product/{Id}")]
        public async Task<IActionResult> GetProductByIdAsync(GetAllProductsQuery command)
        {
            var product = await Mediator.Send(command);
            return Ok(product);
        }
    }
}
