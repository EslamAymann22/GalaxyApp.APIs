using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery
{
    public record GetAllSupplierModel : IRequest<BaseResponse<List<GetAllSupplierDto>>>;

    public class GetAllSupplierHandler : BaseResponseHandler
                                       , IRequestHandler<GetAllSupplierModel, BaseResponse<List<GetAllSupplierDto>>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public GetAllSupplierHandler(ISupplierService supplierService, IMapper mapper)
        {
            this._supplierService = supplierService;
            this._mapper = mapper;
        }


        public async Task<BaseResponse<List<GetAllSupplierDto>>> Handle(GetAllSupplierModel request, CancellationToken cancellationToken)
        {
            var AllSuppliers = await _supplierService.GetAllWithLstPurchaseAsync();
            var Result = _mapper.Map<List<GetAllSupplierDto>>(AllSuppliers);
            return Success(Result);
        }
    }
}
