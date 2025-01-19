using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlliantProductManagementServer.WebAPI.Controllers.Core
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CoreController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public CoreController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
