using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerServices(ICustomerRepo customerRepo)
        {
            this._customerRepo = customerRepo;
        }

        public async Task AddAsync(Customer customer)
        => await _customerRepo.AddAsync(customer);

        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await _customerRepo.GetAllAsync();

        public async Task<Customer> GetByIdAsync(int Id)
            => await _customerRepo.GetByIdAsync(Id);


        public async Task<Customer> GetByPhoneAsync(string Phone)
        => await _customerRepo.GetByPhoneAsync(Phone);
    }
}
