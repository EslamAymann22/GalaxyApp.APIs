using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerPurchaseRepo
    {

        Task<int> AddAsync(CustomerPurchase purchase);
        Task UpdateAsync(CustomerPurchase purchase);


        Task<CustomerPurchase> GetByIdAsync(int Id);
        Task DeleteAsync(CustomerPurchase purchase);


    }
}
