using GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{

    public class CustomerPurchaseController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerPurchaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<string>>> CreateCustomerPurchase([FromBody] CreateCustomerInvoiceModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

    }
}
