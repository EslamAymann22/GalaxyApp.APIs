using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Core.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyApp.Service.Interfaces.ProductInterface;
using AutoMapper;
using GalaxyApp.Data.Entities;
using System.Net;

namespace GalaxyApp.Core.Features.Products.Commands.CreateCommand
{

    public record CreateProductModel : IRequest<BaseResponse<CreateProductModel>>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public int Evaluation { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal sellingPrice { get; set; }

    }

    public class CreateProductHandler : BaseResponseHandler,
        IRequestHandler<CreateProductModel, BaseResponse<CreateProductModel>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductService productService 
                                    ,IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<CreateProductModel>> Handle(CreateProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var Result =await _productService.AddAsync(product);

            return Result
                ?Created(request)
                : Failed<CreateProductModel>(HttpStatusCode.Conflict);
        }
    }
}
