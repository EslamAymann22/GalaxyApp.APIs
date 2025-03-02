using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Service.Interfaces
{
    public interface ICustomerServices
    {

        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int Id);
        Task<Customer> GetByPhoneAsync(string Phone);
        Task AddAsync(Customer customer);


    }
}
