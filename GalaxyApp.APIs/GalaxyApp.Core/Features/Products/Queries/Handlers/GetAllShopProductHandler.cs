using AutoMapper;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;

namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{
    public class GetAllShopProductModel : PaginationParams, IRequest<BaseResponse<PaginatedResponse<GetAllShopProductDto>>>;

    public class GetAllShopProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllShopProductModel, BaseResponse<PaginatedResponse<GetAllShopProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllShopProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResponse<GetAllShopProductDto>>> Handle(GetAllShopProductModel request, CancellationToken cancellationToken)
        {
            var QueryableDate = _productService.GetQueryableNoTracking();
            QueryableDate = _productService.ApplyOrderByAndSearchFilter
                (QueryableDate, request.OrderFilter, request.SearchFilter);
            var QueryableList = _mapper.ProjectTo<GetAllShopProductDto>(QueryableDate);

            return Success(await QueryableList.ToPaginatedListAsync(request.PageNumber, request.PageSize));
        }
    }

}
