using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class PurchaseService : IPurchaseService
    {

        private readonly IPurchaseRepo _purchaseRepo;
        private readonly IProductService _productService;

        public PurchaseService(IPurchaseRepo purchaseRepo
                               , IProductService productService)
        {
            this._purchaseRepo = purchaseRepo;
            this._productService = productService;
        }

        public async Task<int> AddAsync(Purchase purchase)
            => await _purchaseRepo.AddAsync(purchase);

        public async Task AddPurchaseProducts(Purchase purchase)
        {
            foreach (var purchaseItem in purchase.PurchaseItems)
            {
                var product = await _productService.GetByIdAsync(purchaseItem.ProductId);
                product.WarehouseQuantity += purchaseItem.Quantity;
                _productService.Update(product);
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var DeletedPurchase = await _purchaseRepo.GetByIdAsync(Id);
            if (DeletedPurchase is not null)
            {
                await _purchaseRepo.DeleteAsync(DeletedPurchase);
                return true;
            }
            return false;
        }

        public async Task<List<Purchase>> GetAllAsync()
        => await _purchaseRepo.GetAllAsync();

        public async Task<Purchase> GetByIdAsync(int Id)
            => await _purchaseRepo.GetByIdAsync(Id);

        public IQueryable<Purchase> GetQueryableNoTracking()
            => _purchaseRepo.GetQueryableNoTracking();

        public async Task UpdateAsync(Purchase purchase)
           => await _purchaseRepo.UpdateAsync(purchase);

    }
}
