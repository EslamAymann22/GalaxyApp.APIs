using GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{
    public class PurchaseController : BaseController
    {
        private readonly IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }



        [HttpPost]
        public async Task<BaseResponse<string>> CreatePurchase([FromBody] CreatePurchaseModel Model)
        {

            return await _mediator.Send(Model);

        }

    }


}
