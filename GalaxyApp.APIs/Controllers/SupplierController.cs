using GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{

    public class SupplierController : BaseController
    {
        private readonly IMediator _mediator;


        public SupplierController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [Authorize(Roles = "Manager,Owner")]
        [HttpPost("AddSupplier")]
        public async Task<ActionResult<BaseResponse<CreateSupplierModel>>> AddSupplier([FromForm] CreateSupplierModel Model)
        {
            return Ok(await _mediator.Send(Model));
        }

        [Authorize(Roles = "Manager,Owner")]
        [HttpGet("GetAllSuppliers")]
        public async Task<ActionResult<BaseResponse<GetAllSupplierDto>>> GetAllSuppliers()
        {
            return Ok(await _mediator.Send(new GetAllSupplierModel()));
        }

    }
}
