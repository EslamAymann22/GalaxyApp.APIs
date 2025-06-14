using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ISupplierRepo
    {

        public Task<IEnumerable<Supplier>> GetAllAsync();
        public Task<IEnumerable<Supplier>> GetAllWithLstPurchaseAsync();
        public Task<Supplier?> GetByIdAsync(int id);
        public Task<Supplier> GetByIdWithPurchaseAsync(int id);
        public Task AddAsync(Supplier supplier);

        public Task UpdateAsync(Supplier supplier);


    }
}
