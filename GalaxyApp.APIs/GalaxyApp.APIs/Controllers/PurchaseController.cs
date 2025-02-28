using GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Purchases.Queries;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{
    public class PurchaseController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IPurchaseService __purchaseService;

        public PurchaseController(IMediator mediator
            , IPurchaseService purchaseService)
        {
            this._mediator = mediator;
            this.__purchaseService = purchaseService;
        }



        [HttpPost]
        public async Task<BaseResponse<string>> CreatePurchase([FromBody] CreatePurchaseModel Model)
        {
            return await _mediator.Send(Model);
        }


        [HttpGet]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<GetAllPurchaseDto>>>> GetAllPurchase([FromQuery] GetAllPurchaseModel Model)
        {
            return Ok(await _mediator.Send(Model));

        }

    }


}
