using GalaxyApp.Core.Features.Customers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Customers.Queries;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
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
        [Authorize(Roles = "seller")]
        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<GetCustomersDto>>>> GetAllCustomers([FromQuery] GetAllCustomersModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [Authorize(Roles = "seller")]
        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<BaseResponse<GetCustomersDto>>> GetCustomerById([FromQuery] GetCustomerByIdModel model)
        {
            return BaseOk(await _mediator.Send(model));

        }
    }
}
