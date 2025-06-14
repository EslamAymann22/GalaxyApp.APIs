using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class ProductRepo : IProductRepo
    {
        private readonly GalaxyDbContext _DbContext;

        public ProductRepo(GalaxyDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _DbContext.products.AddAsync(product);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
            => await _DbContext.products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
        => await _DbContext.products.Where(P => P.Id == id).FirstOrDefaultAsync();

        public void Update(Product product)
        {
            _DbContext.products.Update(product);
            _DbContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _DbContext.products.Remove(product);
            _DbContext.SaveChanges();
        }

        public IQueryable<Product> GetQueryableNoTracking()
        => _DbContext.products.AsNoTracking().AsQueryable();
    }
}
