using AutoMapper;
using GalaxyApp.Core.BaseResponse;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;


namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{

    public record GetAllProductModel : IRequest<BaseResponse<List<GetAllProductDto>>>;


    public class GetAllProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllProductModel, BaseResponse<List<GetAllProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }


        public async Task<BaseResponse<List<GetAllProductDto>>> Handle(GetAllProductModel request, CancellationToken cancellationToken)
        {
            var ProductList = await _productService.GetAllAsync();
            var MappedProduct = _mapper.Map<List<GetAllProductDto>>(ProductList);

            return Success(MappedProduct);
        }
    }

}
