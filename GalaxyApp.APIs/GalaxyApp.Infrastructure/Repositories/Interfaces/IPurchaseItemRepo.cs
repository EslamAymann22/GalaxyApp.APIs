using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface IPurchaseItemRepo
    {

        Task<PurchaseItems> GetAllWithProductAsync();
        Task<PurchaseItems> GetByIdWithProductAsync();
        Task<int> AddAsync(PurchaseItems purchaseItems);
    }
}
