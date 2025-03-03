using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Service.Interfaces
{
    public interface ICustomerPurchaseServices
    {
        Task<int> AddAsync(CustomerPurchase purchase);
        Task UpdateAsync(CustomerPurchase purchase);
        Task DeleteAsync(int Id);
        Task<CustomerPurchase> GetByIdAsync(int Id);

        Task<bool> CheckQuantityOfProducts(CustomerPurchase purchase);

    }
}
