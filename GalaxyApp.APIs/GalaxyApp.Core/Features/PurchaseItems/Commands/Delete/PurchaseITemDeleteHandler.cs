using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.PurchaseItem.Commands.Delete
{

    public class PurchaseITemDeleteModel : IRequest<BaseResponse<string>>
    {
        public int ID { get; set; }
    }


    public class PurchaseITemDeleteHandler : BaseResponseHandler, IRequestHandler<PurchaseITemDeleteModel, BaseResponse<string>>
    {
        private readonly IPurchaseItemService _purchaseItemService;

        public PurchaseITemDeleteHandler(IPurchaseItemService purchaseItemService)
        {
            this._purchaseItemService = purchaseItemService;
        }

        public async Task<BaseResponse<string>> Handle(PurchaseITemDeleteModel request, CancellationToken cancellationToken)
        {
            var Resutl = await _purchaseItemService.DeleteAsync(request.ID);

            if (Resutl)
                return Deleted<string>();

            return Failed<string>(System.Net.HttpStatusCode.NotFound);

        }
    }
}
