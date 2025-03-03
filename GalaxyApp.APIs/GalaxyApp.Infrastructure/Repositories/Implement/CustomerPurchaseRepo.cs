using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class CustomerPurchaseRepo : ICustomerPurchaseRepo
    {
        private readonly GalaxyDbContext _galaxyDbContext;

        public CustomerPurchaseRepo(GalaxyDbContext galaxyDbContext)
        {
            this._galaxyDbContext = galaxyDbContext;
        }



        public async Task<int> AddAsync(CustomerPurchase purchase)
        {
            await _galaxyDbContext.customerPurchases.AddAsync(purchase);
            await _galaxyDbContext.SaveChangesAsync();
            int NewPurchase = (await _galaxyDbContext.customerPurchases.OrderByDescending(P => P.Id).FirstOrDefaultAsync()).Id;
            return NewPurchase;
        }

        public async Task DeleteAsync(CustomerPurchase purchase)
        {
            _galaxyDbContext.customerPurchases.Remove(purchase);
            await _galaxyDbContext.SaveChangesAsync();
        }

        public async Task<CustomerPurchase> GetByIdAsync(int Id)
        => await _galaxyDbContext.customerPurchases.Where(CP => CP.Id == Id).FirstOrDefaultAsync();

        public async Task UpdateAsync(CustomerPurchase purchase)
        {
            _galaxyDbContext.customerPurchases.Update(purchase);
            await _galaxyDbContext.SaveChangesAsync();
        }
    }
}
