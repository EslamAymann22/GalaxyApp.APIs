using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface IPurchaseRepo
    {

        Task<List<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int Id);
        Task<int> AddAsync(Purchase purchase);

        Task UpdateAsync(Purchase purchase);


    }
}
