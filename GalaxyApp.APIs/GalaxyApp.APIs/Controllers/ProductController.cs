using GalaxyApp.Core.Features.Products.Queries.Models;
using GalaxyApp.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {

            return await _mediator.Send(new GetAllProductModel());
        }

    }
}
