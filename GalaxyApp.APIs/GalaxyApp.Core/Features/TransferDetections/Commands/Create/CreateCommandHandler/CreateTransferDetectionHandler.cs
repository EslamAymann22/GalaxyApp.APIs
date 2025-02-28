using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Data.Entities.TransferDetectionFolder;
using GalaxyApp.Service.Interfaces;
using MediatR;
using System.Net;

namespace GalaxyApp.Core.Features.TransferDetections.Commands.Create.CreateCommandHandler
{

    public class CreateTransferDetectionModel : IRequest<BaseResponse<string>>
    {
        public List<CreateTransferDetectionDto> Items { get; set; } = new List<CreateTransferDetectionDto>();
        public TransferDetectionType TransferDetectionType { get; set; }

    }

    public class CreateTransferDetectionHandler : BaseResponseHandler, IRequestHandler<CreateTransferDetectionModel, BaseResponse<string>>
    {
        private readonly ITransferDetectionServices _transferDetectionServices;
        private readonly ITransferDetectionItemsServices _transferDetectionItemsServices;
        private readonly IProductService _productService;

        public CreateTransferDetectionHandler(ITransferDetectionServices transferDetectionServices
                                              , ITransferDetectionItemsServices transferDetectionItemsServices
                                               , IProductService productService)
        {
            this._transferDetectionServices = transferDetectionServices;
            this._transferDetectionItemsServices = transferDetectionItemsServices;
            this._productService = productService;
        }

        public async Task<BaseResponse<string>> Handle(CreateTransferDetectionModel request, CancellationToken cancellationToken)
        {

            TransferDetection CreatedTransDet = new TransferDetection()
            {
                transferDetectionType = request.TransferDetectionType
            };

            int TransferDetectionId = await _transferDetectionServices.AddAsync(CreatedTransDet);

            bool CanCreateAllItems = true;

            foreach (var item in request.Items)
            {
                TransferDetectionItems TDItems = new TransferDetectionItems()
                {
                    Quantity = item.Quantity
                };

                CanCreateAllItems &= await _productService.ChangeQuantityAsync(item.ProductId, item.Quantity, request.TransferDetectionType, false);
            }

            if (!CanCreateAllItems)
            {
                return Failed<string>(HttpStatusCode.UnprocessableContent, "The quantity is not enough");
            }


            foreach (var item in request.Items)
            {
                TransferDetectionItems TDItems = new TransferDetectionItems()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TransferDetectionId = TransferDetectionId
                };

                var NewTDItemId = await _transferDetectionItemsServices.AddAsync(TDItems);
                await _productService.ChangeQuantityAsync(item.ProductId, item.Quantity, request.TransferDetectionType, true);

            }
            await _transferDetectionServices.UpdateAsync(CreatedTransDet);
            return Success("Purchase Created Successfully");

        }
    }
}
