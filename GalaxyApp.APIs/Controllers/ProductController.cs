using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Commands.Delete;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "seller")]
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<PaginatedResponse<GetAllProductDto>>> GetAllProducts([FromQuery] GetAllProductModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }



        //[HttpGet("GetAllShopProducts")]
        //public async Task<ActionResult<BaseResponse<List<GetAllProductDto>>>> GetAllShopProducts([FromQuery] GetAllShopProductModel model)
        //{
        //    return BaseOk(await _mediator.Send(model));
        //}
        //[HttpGet("GetAllWarehouseProducts")]
        //public async Task<ActionResult<BaseResponse<List<GetAllProductDto>>>> GetAllWarehouseProducts([FromQuery] GetAllWarehouseProductModel model)
        //{
        //    return BaseOk(await _mediator.Send(model));
        //}
        [Authorize(Roles = "Manager,Owner")]
        [HttpPost("AddProduct")]
        //[Authorize]
        public async Task<ActionResult<BaseResponse<CreateProductModel>>> CreateProduct([FromForm] CreateProductModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }
        [Authorize(Roles = "Manager,Owner")]
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<BaseResponse<UpdateProductModel>>> UpdateProduct([FromQuery] UpdateProductModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

        [Authorize(Roles = "Manager,Owner")]
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<BaseResponse<DeleteProductHandler>>> DeleteProduct([FromQuery] DeleteProductModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

    }
}
