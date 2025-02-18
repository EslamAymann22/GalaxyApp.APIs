using Azure;
using GalaxyApp.Core.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GalaxyApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        private IMediator _mediatorInstance;
        protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();



        public ObjectResult NewOk<T>(BaseResponse<T> response)
        {
            return (object)response.Status switch
            {
                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.Conflict => new ConflictObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                _ => new BadRequestObjectResult(response),
            };
        }


    }
}
