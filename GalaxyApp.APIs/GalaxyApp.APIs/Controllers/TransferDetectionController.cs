using GalaxyApp.Core.Features.TransferDetections.Commands.Create.CreateCommandHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{
    public class TransferDetectionController : BaseController
    {
        private readonly IMediator _mediator;

        public TransferDetectionController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateTransferDetection([FromBody] CreateTransferDetectionModel Model)
        {
            return BaseOk(await _mediator.Send(Model));
        }

    }
}
