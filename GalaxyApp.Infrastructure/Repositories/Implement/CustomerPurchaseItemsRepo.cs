using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class CustomerPurchaseItemsRepo : ICustomerPurchaseItemsRepo
    {
        private readonly GalaxyDbContext _galaxyDbContext;

        public CustomerPurchaseItemsRepo(GalaxyDbContext galaxyDbContext)
        {
            this._galaxyDbContext = galaxyDbContext;
        }
        public async Task AddAsync(CustomerPurchaseItem item)
        {
            await _galaxyDbContext.customerPurchaseItems.AddAsync(item);
            await _galaxyDbContext.SaveChangesAsync();
        }
    }
}
