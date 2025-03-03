using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler
{

    public class CreateCustomerInvoiceModel : IRequest<BaseResponse<string>>
    {
        public int CustomerId { get; set; }
        public List<CustomerInvoiceItemsDto> CInvoiceItems { get; set; } = new List<CustomerInvoiceItemsDto>();
    }
    public class CreateCustomerInvoiceHandler : BaseResponseHandler,
                                                IRequestHandler<CreateCustomerInvoiceModel, BaseResponse<string>>
    {
        private readonly ICustomerPurchaseServices _customerPurchaseServices;
        private readonly ICustomerPurchaseItemsRepo _customerPurchaseItemsRepo;

        public CreateCustomerInvoiceHandler(ICustomerPurchaseServices customerPurchaseServices
                                           , ICustomerPurchaseItemsRepo customerPurchaseItemsRepo)
        {
            this._customerPurchaseServices = customerPurchaseServices;
            this._customerPurchaseItemsRepo = customerPurchaseItemsRepo;
        }
        public async Task<BaseResponse<string>> Handle(CreateCustomerInvoiceModel request, CancellationToken cancellationToken)
        {

            var CreatedPurchase = new CustomerPurchase()
            {
                CustomerId = request.CustomerId
            };

            int NewPurchaseId = await _customerPurchaseServices.AddAsync(CreatedPurchase);




            foreach (var item in request.CInvoiceItems)
            {
                var CreatedInvoiceItems = new CustomerPurchaseItem()
                {
                    CustomerPurchaseId = NewPurchaseId,
                    Discount = item.Discount,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };
                await _customerPurchaseItemsRepo.AddAsync(CreatedInvoiceItems);
                CreatedPurchase.purchaseItems.Add(CreatedInvoiceItems);
            }

            var Result = await _customerPurchaseServices.CheckQuantityOfProducts(CreatedPurchase);

            if (!Result)
            {
                await _customerPurchaseServices.DeleteAsync(NewPurchaseId);
                return Failed<string>(System.Net.HttpStatusCode.BadRequest, "Quantity isn't enough");
            }
            CreatedPurchase.purchaseItems.Clear();
            await _customerPurchaseServices.UpdateAsync(CreatedPurchase);

            return Success<string>();

        }
    }
}
