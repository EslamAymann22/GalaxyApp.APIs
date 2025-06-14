using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class CustomerPurchaseServices : ICustomerPurchaseServices
    {
        private readonly ICustomerPurchaseRepo _customerPurchaseRepo;
        private readonly IProductService _productService;

        public CustomerPurchaseServices(ICustomerPurchaseRepo customerPurchaseRepo
                                       , IProductService productService)
        {
            this._customerPurchaseRepo = customerPurchaseRepo;
            this._productService = productService;
        }
        public async Task<int> AddAsync(CustomerPurchase purchase)
        {
            return await _customerPurchaseRepo.AddAsync(purchase);
        }

        public IQueryable<CustomerPurchase> ApplySearchFilter(IQueryable<CustomerPurchase> Data, string? Search)
        {
            if (Search is not null)
            {
                Search = Search.ToLower();
                Data = Data.Where(P => P.Customer.Name.ToLower().Contains(Search)
                                    || P.Customer.Phone.Contains(Search));
            }

            return Data;

        }

        public async Task<bool> CheckQuantityOfProducts(CustomerPurchase purchase)
        {
            Dictionary<int, int> mp = new Dictionary<int, int>();
            foreach (var item in purchase.purchaseItems)
            {
                if (mp.ContainsKey(item.ProductId))
                {
                    mp[item.ProductId] += item.Quantity;
                }
                else
                {
                    mp.Add(item.ProductId, item.Quantity);
                }
            }

            foreach (var item in mp)
            {
                var prod = await _productService.GetByIdAsync(item.Key);
                if (prod.ShopQuantity < item.Value) return false;
            }
            foreach (var item in mp)
            {
                var prod = await _productService.GetByIdAsync(item.Key);
                prod.ShopQuantity -= item.Value;
                _productService.Update(prod);
            }
            return true;

        }

        public async Task DeleteAsync(int Id)
        {
            var DeletedPurchase = await _customerPurchaseRepo.GetByIdAsync(Id);
            await _customerPurchaseRepo.DeleteAsync(DeletedPurchase);
        }

        public async Task<CustomerPurchase> GetByIdAsync(int Id)
        {
            return await _customerPurchaseRepo.GetByIdAsync(Id);
        }

        public IQueryable<CustomerPurchase> GetQueryableNoTracking()
            => _customerPurchaseRepo.GetQueryableNoTracking();


        public async Task UpdateAsync(CustomerPurchase purchase)
        {
            await _customerPurchaseRepo.UpdateAsync(purchase);
        }



    }
}
