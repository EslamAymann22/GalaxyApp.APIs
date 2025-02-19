using GalaxyApp.Core.BaseResponse;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Commands.Delete;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
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
        public async Task<ActionResult<BaseResponse<List<GetAllProductDto>>>> GetAllProducts()
        {
            return NewOk(await _mediator.Send(new GetAllProductModel()));
        }

        [HttpGet("Shop")]
        public async Task<ActionResult<BaseResponse<List<GetAllShopProductDto>>>> GetAllShopProducts()
        {
            return NewOk(await _mediator.Send(new GetAllShopProductModel()));
        }
        [HttpGet("Warehouse")]
        public async Task<ActionResult<BaseResponse<List<GetAllWarehouseProductDto>>>> GetAllWarehouseProducts()
        {
            return NewOk(await _mediator.Send(new GetAllWarehouseProductModel()));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateProductModel>>> CreateProduct([FromBody] CreateProductModel model)
        {
            return NewOk(await _mediator.Send(model));
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<UpdateProductModel>>> UpdateProduct([FromBody] UpdateProductModel model)
        {
            return NewOk(await _mediator.Send(model));
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse<DeleteProductHandler>>> DeleteProduct([FromBody] DeleteProductModel model)
        {
            return NewOk(await _mediator.Send(model));
        }

    }
}
