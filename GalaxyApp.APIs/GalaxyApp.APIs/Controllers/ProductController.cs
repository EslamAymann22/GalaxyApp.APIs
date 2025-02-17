using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.ResponseBase;
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
            return await _mediator.Send(new GetAllProductModel());

        }

    }
}
