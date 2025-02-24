using GalaxyApp.Data.Entities;

namespace GalaxyApp.Service.Interfaces
{
    public interface ISupplierService
    {

        Task AddAsync(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<IEnumerable<Supplier>> GetAllWithLstPurchaseAsync();

    }
}
