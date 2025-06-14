using GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{

    public class SupplierController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ISupplierService _supplierService;

        public SupplierController(IMediator mediator, ISupplierService supplierService)
        {
            this._mediator = mediator;
            this._supplierService = supplierService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateSupplierModel>>> CreateSupplier([FromQuery] CreateSupplierModel Model)
        {

            return Ok(await _mediator.Send(Model));

        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<GetAllSupplierDto>>> GetAllSuppliers()
        {
            return Ok(await _mediator.Send(new GetAllSupplierModel()));
        }

    }
}
