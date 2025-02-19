using GalaxyApp.Data.Entities;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepo
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
