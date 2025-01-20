using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Products;
using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Application.Features.Core.Commands;
using AlliantProductManagementServer.Application.Features.Customers.Handlers;
using AlliantProductManagementServer.Application.Features.Customers.Queries;
using AlliantProductManagementServer.Application.Features.ProductCategories.Handlers;
using AlliantProductManagementServer.Application.Features.ProductCategories.Queries;
using AlliantProductManagementServer.WebAPI.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliantProductManagementServer.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Product categories controller management")]
    [Route("api")]
    public class ProductCategoryController(IMediator mediator) : CoreController(mediator)
    {
        [HttpPost("/product/category")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCategoryCommand command)
        {
            var category = await Mediator.Send(command);
            return Created($"/category/{category.Id}", category);
        }

        [HttpGet("/product/categories")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPaginatedCommand<ProductCategoryDto> command)
        {
            var categories = await Mediator.Send(command);
            return Ok(categories);
        }

        [HttpPut("/product/category")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCategoryCommand command)
        {
            var customer = await Mediator.Send(command);
            return Ok(customer);
        }

        [HttpDelete("product/category/{Id}")]
        public async Task<IActionResult> DeleteAsync(DeleteProductCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("product/category/{Id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(GetProductCategoryByIdQuery command)
        {
            var customer = await Mediator.Send(command);
            return Ok(customer);
        }
    }
}
