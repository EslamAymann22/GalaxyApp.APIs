using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class PurchaseItemService : IPurchaseItemService
    {
        private readonly IPurchaseItemRepo _purchaseItemRepo;

        public PurchaseItemService(IPurchaseItemRepo purchaseItemRepo)
        {
            this._purchaseItemRepo = purchaseItemRepo;
        }

        public async Task<int> AddAsync(PurchaseItems purchaseItems)
        {
            return await _purchaseItemRepo.AddAsync(purchaseItems);
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var DeletePurchaseItems = await _purchaseItemRepo.GetByIdWithProductAsync(Id);
            if (DeletePurchaseItems is null) return false;

            await _purchaseItemRepo.DeleteAsync(DeletePurchaseItems);
            return true;
        }

        public Task<PurchaseItems> GetAllWithProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseItems> GetByIdWithProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
