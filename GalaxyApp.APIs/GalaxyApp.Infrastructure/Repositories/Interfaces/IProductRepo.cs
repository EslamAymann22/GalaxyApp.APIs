using GalaxyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepo
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);


    }
}
