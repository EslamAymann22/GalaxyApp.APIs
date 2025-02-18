using AutoMapper;
using GalaxyApp.Core.BaseResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;
using System.Net;

namespace GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler
{

    public record UpdateProductModel : IRequest<BaseResponse<UpdateProductModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImageFileName { get; set; }
        public int Evaluation { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal sellingPrice { get; set; }
        public decimal Discount { get; set; }
        public int WarehouseQuantity { get; set; }
        public int ShopQuantity { get; set; }
    }

    public class UpdateProductHandler : BaseResponseHandler
                                     , IRequestHandler<UpdateProductModel, BaseResponse<UpdateProductModel>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<UpdateProductModel>> Handle(UpdateProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var Result = await _productService.CheckProductUpdate(product);

            if (Result == HttpStatusCode.OK)
            {
                var SearchProd = await _productService.GetByIdAsync(product.Id);

                SearchProd.Name = product.Name;
                SearchProd.Color = product.Color;
                SearchProd.Discount = product.Discount;
                SearchProd.Evaluation = product.Evaluation;
                SearchProd.PurchasingPrice = product.PurchasingPrice;
                SearchProd.sellingPrice = product.sellingPrice;
                SearchProd.ImageFileName = product.ImageFileName;
                SearchProd.ShopQuantity = product.ShopQuantity;
                SearchProd.WarehouseQuantity = product.WarehouseQuantity;

                _productService.Update(SearchProd);
                return Updated(request);
            }

            return Failed<UpdateProductModel>(Result);


            //return Result ? Updated(request) : Failed<UpdateProductModel>(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
