using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ISupplierRepo
    {

        public Task<IEnumerable<Supplier>> GetAllAsync();
        Task<IEnumerable<Supplier>> GetAllWithLstPurchaseAsync();
        //public Supplier GetByIdAsync(int id);
        public Task AddAsync(Supplier supplier);


    }
}
