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
        => await _dbContext.suppliers.Include(P => P.LatestPurchase).ToListAsync();

    }
}
