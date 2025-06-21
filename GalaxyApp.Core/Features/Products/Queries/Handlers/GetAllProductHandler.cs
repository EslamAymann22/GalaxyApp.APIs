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
        public ProductOrderEnum? OrderFilter { get; set; } = ProductOrderEnum.Id;
        public GetAllProductsEnum GetProductsType { get; set; } = GetAllProductsEnum.AllProducts;

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
            var MappedList = (_mapper.Map<List<GetAllProductDto>>(QueryableDate));

            var QueryableList = QueryableDate.ToList();



            int BagStart = (request.PageNumber - 1) * request.PageSize;
            int BagEnd = request.PageNumber * request.PageSize;
            BagEnd = Math.Min(BagEnd, QueryableList.Count);



            for (int idx = BagStart; idx < BagEnd; idx++)
            {
                if (request.GetProductsType == GetAllProductsEnum.ShopProducts)
                    MappedList[idx].Quantity = QueryableList[idx].ShopQuantity;

                else if (request.GetProductsType == GetAllProductsEnum.WarehouseProducts)
                    MappedList[idx].Quantity = QueryableList[idx].WarehouseQuantity;

            }
            return Success(await MappedList.ToPaginatedListAsync(request.PageNumber, request.PageSize));
        }
    }

}
