using GalaxyApp.Core.Features.Products.Queries.Models;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{



    public class GetAllProductHandler : IRequestHandler<GetAllProductModel, List<Product>>
    {
        private readonly IProductService _productService;

        public GetAllProductHandler(IProductService productService)
        {
            this._productService = productService;
        }


        public async Task<List<Product>> Handle(GetAllProductModel request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync();

        }
    }

}
