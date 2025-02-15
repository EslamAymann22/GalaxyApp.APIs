using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class ProductRepo : IProductRepo
    {
        private readonly GalaxyDbContext _DbContext;

        public ProductRepo(GalaxyDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<List<Product>> GetAllAsync()
            => await _DbContext.products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
        => await _DbContext.products.Where(P => P.Id == id).FirstOrDefaultAsync();
    }
}
