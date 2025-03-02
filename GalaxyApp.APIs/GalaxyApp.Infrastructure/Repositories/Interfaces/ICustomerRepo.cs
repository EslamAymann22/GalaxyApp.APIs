using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepo
    {

        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int Id);
        Task<Customer> GetByPhoneAsync(string Phone);
        Task AddAsync(Customer customer);

    }
}
