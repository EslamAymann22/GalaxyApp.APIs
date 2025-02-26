﻿using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandHandler
{

    public class CreatePurchaseModel : IRequest<BaseResponse<string>>
    {
        public int SupplierId { get; set; }
        public List<CreateInvoiceItemDto> PurchaseItems { get; set; }

    }


    public class CreatePurchaseHandler : BaseResponseHandler, IRequestHandler<CreatePurchaseModel, BaseResponse<string>>
    {
        private readonly IPurchaseItemService _purchaseItemService;
        private readonly IPurchaseService _purchaseService;
        private readonly ISupplierService _supplierService;

        public CreatePurchaseHandler(IPurchaseItemService purchaseItemService
                                    , IPurchaseService purchaseService
                                    , ISupplierService supplierService)
        {
            this._purchaseItemService = purchaseItemService;
            this._purchaseService = purchaseService;
            this._supplierService = supplierService;
        }

        public async Task<BaseResponse<string>> Handle(CreatePurchaseModel request, CancellationToken cancellationToken)
        {

            Purchase CreatedPurchase = new Purchase()
            {
                SupplierId = request.SupplierId
            };

            int NewPurchaseId = await _purchaseService.AddAsync(CreatedPurchase);

            // Update Supplier Latest Purchase 
            #region Update Supplier Latest Purchase 
            Supplier UpdatedSupplier = await _supplierService.GetByIdAsync(request.SupplierId);
            UpdatedSupplier.LatestPurchaseId = NewPurchaseId;
            #endregion

            foreach (var item in request.PurchaseItems)
            {
                PurchaseItems purchaseItems = new PurchaseItems()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Discount = item.Discount,
                    PurchaseId = NewPurchaseId
                };

                var NewPurchaseItemId = await _purchaseItemService.AddAsync(purchaseItems);
                CreatedPurchase.PurchaseItems.Add(purchaseItems);
            }

            await _purchaseService.UpdateAsync(CreatedPurchase);
            await _purchaseService.AddPurchaseProducts(CreatedPurchase);


            return Success("Purchase Created Successfully");

        }
    }
}
