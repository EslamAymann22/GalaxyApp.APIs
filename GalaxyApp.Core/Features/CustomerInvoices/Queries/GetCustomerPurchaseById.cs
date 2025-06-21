using GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Infrastructure.DbContextData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Core.Features.CustomerInvoices.Queries
{
    public class GetCustomerPurchaseByIdDto
    {
        public decimal TotalPrice { get; set; }
        public DateTime creationDate { get; set; }
        public List<PurchaseItemsDto> items { get; set; } = new List<PurchaseItemsDto>();
    }


    public class GetCustomerPurchaseByIdModel : IRequest<BaseResponse<GetCustomerPurchaseByIdDto>>
    {
        public int Id { get; set; }
    }



    public class GetCustomerPurchaseByIdHandler : BaseResponseHandler, IRequestHandler<GetCustomerPurchaseByIdModel, BaseResponse<GetCustomerPurchaseByIdDto>>
    {
        private readonly GalaxyDbContext _galaxyDb;

        public GetCustomerPurchaseByIdHandler(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }
        public async Task<BaseResponse<GetCustomerPurchaseByIdDto>> Handle(GetCustomerPurchaseByIdModel request, CancellationToken cancellationToken)
        {


            var CustomerPurchase = await _galaxyDb.customerPurchases.Include(Cp => Cp.purchaseItems).ThenInclude(PI => PI.Product)
                .Where(C => C.Id == request.Id)
                .Select(C =>
                new GetCustomerPurchaseByIdDto
                {
                    TotalPrice = C.TotalPrice,
                    creationDate = C.Date,
                    items = C.purchaseItems.Select(pi => new PurchaseItemsDto
                    {
                        ProductName = pi.Product.Name,
                        Price = pi.Product.sellingPrice,
                        Quantity = pi.Quantity
                    }).ToList()
                }).FirstOrDefaultAsync();

            return Success(CustomerPurchase);

        }
    }
}