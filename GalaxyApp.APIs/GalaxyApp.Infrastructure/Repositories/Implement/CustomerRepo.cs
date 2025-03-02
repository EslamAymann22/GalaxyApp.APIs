using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly GalaxyDbContext _galaxyDb;

        public CustomerRepo(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }

        public async Task AddAsync(Customer customer)
        {
            await _galaxyDb.customers.AddAsync(customer);
            await _galaxyDb.SaveChangesAsync();
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await _galaxyDb.customers.ToListAsync();

        public async Task<Customer> GetByIdAsync(int Id)
         => await _galaxyDb.customers.Where(C => C.Id == Id).FirstOrDefaultAsync();

        public async Task<Customer> GetByPhoneAsync(string Phone)
        => await _galaxyDb.customers.Where(C => C.Phone == Phone).FirstOrDefaultAsync();
    }
}
