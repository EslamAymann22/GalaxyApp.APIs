using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Commands.Delete;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<PaginatedResponse<GetAllProductDto>>> GetAllProducts([FromQuery] GetAllProductModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }



        [HttpGet("Shop")]
        public async Task<ActionResult<BaseResponse<List<GetAllShopProductDto>>>> GetAllShopProducts([FromQuery] GetAllShopProductModel model)
        {
            return Ok(await _mediator.Send(model));
        }
        [HttpGet("Warehouse")]
        public async Task<ActionResult<BaseResponse<List<GetAllWarehouseProductDto>>>> GetAllWarehouseProducts([FromQuery] GetAllWarehouseProductModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateProductModel>>> CreateProduct([FromQuery] CreateProductModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<UpdateProductModel>>> UpdateProduct([FromQuery] UpdateProductModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse<DeleteProductHandler>>> DeleteProduct([FromQuery] DeleteProductModel model)
        {
            return Ok(await _mediator.Send(model));
        }

    }
}
