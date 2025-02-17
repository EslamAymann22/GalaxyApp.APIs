using GalaxyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Service.Interfaces.ProductInterface
{
    public interface IProductService
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int Id);

        Task<bool> AddAsync(Product product);

    }
}
