using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public IFormFile? Image { get; set; }

        public class UpdateProductHandler : BaseResponseHandler
                                         , IRequestHandler<UpdateProductModel, BaseResponse<UpdateProductModel>>
        {
            private readonly IProductService _productService;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IMapper _mapper;
            private readonly IFileServices _fileServices;

            public UpdateProductHandler(IProductService productService, IHttpContextAccessor httpContextAccessor
                                    , IMapper mapper, IFileServices fileServices)
            {
                this._productService = productService;
                this._httpContextAccessor = httpContextAccessor;
                this._mapper = mapper;
                this._fileServices = fileServices;
            }

            public async Task<BaseResponse<UpdateProductModel>> Handle(UpdateProductModel request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);

                var Result = await _productService.CheckProductUpdate(product);

                if (Result == HttpStatusCode.OK)
                {
                    var UpdatedProduct = await _productService.GetByIdAsync(product.Id);

                    _mapper.Map(product, UpdatedProduct); // put "product" PaginatedData in "UpdatedProduct"
                    if (request.Image is null) UpdatedProduct.ImageUrl = null;
                    else
                    {
                        var filePath = _fileServices.UploadFile(request.Image, "Products");
                        var Request = _httpContextAccessor.HttpContext.Request;
                        var baseUrl = $"{Request.Scheme}://{Request.Host}";
                        UpdatedProduct.ImageUrl = $"{baseUrl}/{filePath}";
                    };

                    _productService.Update(UpdatedProduct);
                    return Updated(request);
                }

                return Failed<UpdateProductModel>(Result);
            }
        }
    }
}
