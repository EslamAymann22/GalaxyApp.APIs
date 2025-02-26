using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class PurchaseItemRepo : IPurchaseItemRepo
    {
        private readonly GalaxyDbContext _galaxyDb;

        public PurchaseItemRepo(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }

        public async Task<int> AddAsync(PurchaseItems purchaseItems)
        {
            await _galaxyDb.AddAsync(purchaseItems);
            await _galaxyDb.SaveChangesAsync();
            int PIId = (await _galaxyDb.purchaseItems.OrderByDescending(PI => PI.Id).FirstOrDefaultAsync()).Id;
            return PIId;
        }

        public Task<PurchaseItems> GetAllWithProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseItems> GetByIdWithProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
