using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface IPurchaseItemRepo
    {

        Task<List<PurchaseItems>> GetAllWithProductAsync();
        Task<PurchaseItems> GetByIdWithProductAsync(int id);
        Task<int> AddAsync(PurchaseItems purchaseItems);
        Task DeleteAsync(PurchaseItems purchaseItems);
    }
}
