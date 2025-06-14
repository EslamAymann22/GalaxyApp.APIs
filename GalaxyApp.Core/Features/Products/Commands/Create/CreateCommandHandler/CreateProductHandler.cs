using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler
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
                                    , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateProductModel>> Handle(CreateProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _productService.AddAsync(product);

            return Created(request);
        }
    }
}
