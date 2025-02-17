using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Service.Implement.ProductImp
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }

        public async Task<bool> AddAsync(Product product)
        {
            var productToAdd = (await _productRepo.GetAllAsync())
                .Where(P => P.Color == product.Color && P.Name == product.Name).FirstOrDefault();

            if (productToAdd != null) return false;

            await _productRepo.AddAsync(product);
            return true;

        }

        public async Task<List<Product>> GetAllAsync()
        => await _productRepo.GetAllAsync();

        public async Task<Product> GetByIdAsync(int Id)
        => await _productRepo.GetByIdAsync(Id);
    }
}
