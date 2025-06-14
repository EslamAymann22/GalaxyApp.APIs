using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler
{

    public record CreateProductModel : IRequest<BaseResponse<string>>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public int Evaluation { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal sellingPrice { get; set; }
        public IFormFile? Image { get; set; }

    }

    public class CreateProductHandler : BaseResponseHandler,
        IRequestHandler<CreateProductModel, BaseResponse<string>>
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IFileServices _fileServices;

        public CreateProductHandler(IProductService productService, IHttpContextAccessor httpContextAccessor
                                    , IMapper mapper, IFileServices fileServices)
        {
            _productService = productService;
            this._httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            this._fileServices = fileServices;
        }

        public async Task<BaseResponse<string>> Handle(CreateProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            if (request.Image is not null)
            {

                var fileName = _fileServices.UploadFile(request.Image, "Products");
                var Request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                product.ImageUrl = $"{baseUrl}/{fileName}";
            }

            await _productService.AddAsync(product);
            return Success("Product has been added");
        }
    }
}
