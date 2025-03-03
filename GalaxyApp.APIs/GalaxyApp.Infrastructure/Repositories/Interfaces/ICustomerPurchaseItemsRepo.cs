using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerPurchaseItemsRepo
    {

        Task AddAsync(CustomerPurchaseItem item);

    }
}
