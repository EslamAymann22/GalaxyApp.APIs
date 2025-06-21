using GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.CustomerInvoices.Queries;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{
    [Authorize(Roles = "seller")]
    public class CustomerPurchaseController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerPurchaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateCustomerPurchase")]
        public async Task<ActionResult<BaseResponse<string>>> CreateCustomerPurchase([FromBody] CreateCustomerInvoiceModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

        [HttpGet("GetAllCustomerPurchase")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<GetAllCustomerPurchaseDto>>>> GetAllCustomerPurchase([FromQuery] GetAllCustomerInvoicesModel Model)
        {
            return BaseOk(await _mediator.Send(Model));
        }

    }
}
