using GalaxyApp.Data.Entities;
using System.Net;

namespace GalaxyApp.Service.Interfaces.ProductInterface
{
    public interface IProductService
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int Id);

        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);

        Task<HttpStatusCode> CheckProductUpdate(Product product);



    }
}
