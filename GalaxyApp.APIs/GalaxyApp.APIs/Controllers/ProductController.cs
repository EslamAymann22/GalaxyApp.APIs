using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GalaxyApp.Core.Features.Products.Commands.CreateCommand;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;

namespace GalaxyApp.APIs.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<GetAllProductDto>>>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductModel());
        }

        [HttpGet("Shop")]
        public async Task<ActionResult<BaseResponse<List<GetAllShopProductDto>>>> GetAllShopProducts()
        {
            return await _mediator.Send(new GetAllShopProductModel());
        }
        [HttpGet("Warehouse")]
        public async Task<ActionResult<BaseResponse<List<GetAllWarehouseProductDto>>>> GetAllWarehouseProducts()
        {
            return await _mediator.Send(new GetAllWarehouseProductModel());
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateProductModel>>> CreateProduct([FromBody] CreateProductModel model)
        {
            return await _mediator.Send(model);
        }


    }
}
