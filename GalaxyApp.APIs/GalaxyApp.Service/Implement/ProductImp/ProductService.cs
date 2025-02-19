using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces.ProductInterface;
using System.Net;

namespace GalaxyApp.Service.Implement.ProductImp
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }

        /* public async Task<bool> AddAsync(Product product)
         {
             var productToAdd = (await _productRepo.GetAllAsync())
                 .Where(P => P.Color == product.Color && P.Name == product.Name).FirstOrDefault();

             if (productToAdd != null) return false;

             await _productRepo.AddAsync(product);
             return true;

         }*/

        public async Task AddAsync(Product product)
        => await _productRepo.AddAsync(product);

        public async Task<List<Product>> GetAllAsync()
        => await _productRepo.GetAllAsync();

        public async Task<Product> GetByIdAsync(int Id)
        => await _productRepo.GetByIdAsync(Id);

        public async Task<HttpStatusCode> CheckProductUpdate(Product product)
        {
            var SearchProd = await GetByIdAsync(product.Id);

            if (SearchProd is null)
                return HttpStatusCode.NotFound;

            if ((await GetAllAsync())
                .Any(P => P.Name == product.Name
                && P.Color == product.Color
                && P.PurchasingPrice == product.PurchasingPrice
                && P.Id != product.Id))
            {
                return HttpStatusCode.Conflict;
            }

            return HttpStatusCode.OK;
        }

        public void Update(Product product)
        {

            _productRepo.Update(product);

        }

        public void Delete(Product product)
        => _productRepo.Delete(product);
    }
}
