using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly GalaxyDbContext _dbContext;

        public SupplierRepo(GalaxyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _dbContext.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        => await _dbContext.suppliers.ToListAsync();

        public async Task<IEnumerable<Supplier>> GetAllWithLstPurchaseAsync()
        => await _dbContext.suppliers.Include(P => P.LatestPurchase)
            .ThenInclude(LP => LP.PurchaseItems)
            .ThenInclude(PI => PI.ItemProduct).ToListAsync();

        public async Task<Supplier?> GetByIdAsync(int id)
        => await _dbContext.Set<Supplier>().Where(P => P.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Supplier supplier)
        {
            _dbContext.suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync();
        }

        async Task<Supplier?> ISupplierRepo.GetByIdWithPurchaseAsync(int id)
        => await _dbContext.Set<Supplier>().Where(P => P.Id == id).Include(P => P.LatestPurchase).FirstOrDefaultAsync();

    }
}
