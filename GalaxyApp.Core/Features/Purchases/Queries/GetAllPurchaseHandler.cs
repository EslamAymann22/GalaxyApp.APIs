using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Purchases.Queries
{

    public class GetAllPurchaseModel : PaginationParams, IRequest<BaseResponse<PaginatedResponse<GetAllPurchaseDto>>>;

    public class GetAllPurchaseHandler : BaseResponseHandler, IRequestHandler<GetAllPurchaseModel, BaseResponse<PaginatedResponse<GetAllPurchaseDto>>>
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;

        public GetAllPurchaseHandler(IPurchaseService purchaseService, IMapper mapper)
        {
            this._purchaseService = purchaseService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResponse<GetAllPurchaseDto>>> Handle(GetAllPurchaseModel request, CancellationToken cancellationToken)
        {


            var AllPurchases = _purchaseService.GetQueryableNoTracking();

            var MappedPurchase = _mapper.ProjectTo<GetAllPurchaseDto>(AllPurchases);

            return Success(await MappedPurchase.ToPaginatedListAsync(request.PageNumber, request.PageSize));

        }
    }
}
