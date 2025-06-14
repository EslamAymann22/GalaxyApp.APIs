using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class PurchaseRepo : IPurchaseRepo
    {
        private readonly GalaxyDbContext _galaxyDb;

        public PurchaseRepo(GalaxyDbContext galaxyDb)
        {
            _galaxyDb = galaxyDb;
        }

        public async Task<int> AddAsync(Purchase purchase)
        {
            await _galaxyDb.purchases.AddAsync(purchase);
            //await _galaxyDb.AddAsync(purchase);
            await _galaxyDb.SaveChangesAsync();
            int PId = (await _galaxyDb.purchases.OrderByDescending(p => p.Id).FirstOrDefaultAsync()).Id;
            return PId;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _galaxyDb.purchases.Remove(purchase);
            await _galaxyDb.SaveChangesAsync();
        }

        public async Task<List<Purchase>> GetAllAsync()
            => await _galaxyDb.Set<Purchase>().Include(P => P.PurchaseItems).ToListAsync();


        public async Task<Purchase?> GetByIdAsync(int Id)
            => await _galaxyDb.Set<Purchase>()
            .Where(P => P.Id == Id)
            .Include(P => P.PurchaseItems)
            .FirstOrDefaultAsync();

        public IQueryable<Purchase> GetQueryableNoTracking()
          => _galaxyDb.purchases.Include(P => P.PurchaseItems).ThenInclude(PI => PI.ItemProduct).AsNoTracking().AsQueryable();

        public async Task UpdateAsync(Purchase purchase)
        {
            _galaxyDb.purchases.Update(purchase);
            await _galaxyDb.SaveChangesAsync();
        }
    }
}
