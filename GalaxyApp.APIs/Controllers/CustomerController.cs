using GalaxyApp.Core.Features.Customers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{

    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateCustomer")]

        [Authorize(Roles = "seller")]
        public async Task<ActionResult<BaseResponse<CreateCustomerModel>>> CreateCustomer([FromQuery] CreateCustomerModel Model)
        {
            return await _mediator.Send(Model);
        }

    }
}
