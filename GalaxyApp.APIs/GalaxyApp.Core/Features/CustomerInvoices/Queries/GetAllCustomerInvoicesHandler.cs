using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.CustomerInvoices.Queries
{

    public class GetAllCustomerInvoicesModel : PaginationParams, IRequest<BaseResponse<PaginatedResponse<GetAllCustomerPurchaseDto>>>;

    public class GetAllCustomerPurchaseDto
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime PurchseDate { get; set; }
        public int PurchaseId { get; set; }
    }
    public class GetAllCustomerInvoicesHandler : BaseResponseHandler
                    , IRequestHandler<GetAllCustomerInvoicesModel, BaseResponse<PaginatedResponse<GetAllCustomerPurchaseDto>>>
    {
        private readonly ICustomerPurchaseServices _customerPurchaseServices;
        private readonly IMapper _mapper;

        public GetAllCustomerInvoicesHandler(ICustomerPurchaseServices customerPurchaseServices, IMapper mapper)
        {
            this._customerPurchaseServices = customerPurchaseServices;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedResponse<GetAllCustomerPurchaseDto>>> Handle(GetAllCustomerInvoicesModel request, CancellationToken cancellationToken)
        {
            var QueryableDate = _customerPurchaseServices.GetQueryableNoTracking();

            QueryableDate = _customerPurchaseServices.ApplySearchFilter(QueryableDate, request.SearchFilter);

            var QueryableList = _mapper.ProjectTo<GetAllCustomerPurchaseDto>(QueryableDate);

            return Success(await QueryableList.ToPaginatedListAsync(request.PageNumber, request.PageSize));



        }
    }
}
