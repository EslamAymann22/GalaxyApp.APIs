using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;

        public SupplierService(ISupplierRepo supplierRepo)
        {
            this._supplierRepo = supplierRepo;
        }


        public async Task AddAsync(Supplier supplier)
        => await _supplierRepo.AddAsync(supplier);

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        => await _supplierRepo.GetAllAsync();

        public async Task<IEnumerable<Supplier>> GetAllWithLstPurchaseAsync()
        => await _supplierRepo.GetAllWithLstPurchaseAsync();

        public async Task<Supplier?> GetByIdAsync(int id)
            => await _supplierRepo.GetByIdAsync(id);

        public async Task<Supplier?> GetByIdWithLstPurchaseAsync(int id)
            => await _supplierRepo.GetByIdWithPurchaseAsync(id);

        public async Task UpdateAsync(Supplier supplier)
        {
            await _supplierRepo.UpdateAsync(supplier);
        }
    }
}
