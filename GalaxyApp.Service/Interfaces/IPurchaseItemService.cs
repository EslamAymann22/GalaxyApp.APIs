using GalaxyApp.Data.Entities;

namespace GalaxyApp.Service.Interfaces
{
    public interface IPurchaseItemService
    {
        Task<PurchaseItems> GetAllWithProductAsync();
        Task<PurchaseItems> GetByIdWithProductAsync();
        Task<int> AddAsync(PurchaseItems purchaseItems);
        Task<bool> DeleteAsync(int Id);

    }
}
