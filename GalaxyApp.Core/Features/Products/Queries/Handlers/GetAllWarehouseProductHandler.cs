using AutoMapper;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{
    public class GetAllWarehouseProductModel : PaginationParams, IRequest<BaseResponse<PaginatedResponse<GetAllWarehouseProductDto>>>;

    public class GetAllWarehouseProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllWarehouseProductModel, BaseResponse<PaginatedResponse<GetAllWarehouseProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllWarehouseProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResponse<GetAllWarehouseProductDto>>> Handle(GetAllWarehouseProductModel request, CancellationToken cancellationToken)
        {
            var QueryableDate = _productService.GetQueryableNoTracking();
            QueryableDate = _productService.ApplyOrderByAndSearchFilter
                (QueryableDate, request.OrderFilter, request.SearchFilter);
            var QueryableList = _mapper.ProjectTo<GetAllWarehouseProductDto>(QueryableDate);

            return Success(await QueryableList.ToPaginatedListAsync(request.PageNumber, request.PageSize));
        }
    }

}
