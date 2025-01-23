using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Application.Features.Users.Handlers;
using AlliantProductManagementServer.WebAPI.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliantProductManagementServer.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Users controller management")]
    [Route("api")]
    public class UsersController(IMediator mediator) : CoreController(mediator)
    {
        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            var r = Request;
            var user = await Mediator.Send(command);
            return Created($"/user/{user.Id}", user);
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
        public async Task<IActionResult> LogInAsync([FromBody] LogInUserCommand command)
        {
            var r = Request;
            var user = await Mediator.Send(command);
            return Created($"/user/{user.Id}", user);
        }
    }
}
