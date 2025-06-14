using AutoMapper;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{

    public class GetAllProductModel : PaginationParams, IRequest<BaseResponse<PaginatedResponse<GetAllProductDto>>>
    {
        //  public PaginationParams PaginationParams { get; set; }

    }
    public class GetAllProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllProductModel, BaseResponse<PaginatedResponse<GetAllProductDto>>>
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }


        public async Task<BaseResponse<PaginatedResponse<GetAllProductDto>>> Handle(GetAllProductModel request, CancellationToken cancellationToken)
        {

            var QueryableDate = _productService.GetQueryableNoTracking();
            QueryableDate = _productService.ApplyOrderByAndSearchFilter
                (QueryableDate, request.OrderFilter, request.SearchFilter);
            var QueryableList = _mapper.ProjectTo<GetAllProductDto>(QueryableDate);

            return Success(await QueryableList.ToPaginatedListAsync(request.PageNumber, request.PageSize));
        }
    }

}
