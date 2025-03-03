using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Purchases.Commands.Delete
{

    public class DeletePurchaseModel : IRequest<BaseResponse<string>> { public int Id { get; set; } }

    public class DeletePurchaseHandler : BaseResponseHandler, IRequestHandler<DeletePurchaseModel, BaseResponse<string>>
    {
        private readonly IPurchaseService _purchaseService;

        public DeletePurchaseHandler(IPurchaseService purchaseService)
        {
            this._purchaseService = purchaseService;
        }

        public async Task<BaseResponse<string>> Handle(DeletePurchaseModel request, CancellationToken cancellationToken)
        {
            var Result = await _purchaseService.DeleteAsync(request.Id);
            if (Result)
                return Deleted<string>();
            return Failed<string>(System.Net.HttpStatusCode.NotFound);
        }
    }
}
