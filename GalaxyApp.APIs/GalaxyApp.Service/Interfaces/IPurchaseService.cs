using GalaxyApp.Data.Entities;

namespace GalaxyApp.Service.Interfaces
{
    public interface IPurchaseService
    {

        Task<List<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int Id);

        Task<int> AddAsync(Purchase purchase);

        Task UpdateAsync(Purchase purchase);

        Task AddPurchaseProducts(Purchase purchase);

    }
}
