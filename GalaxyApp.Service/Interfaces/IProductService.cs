using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Data.Entities;
using System.Net;


namespace GalaxyApp.Service.Interfaces
{
    public interface IProductService
    {

        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int Id);

        Task AddAsync(Product product);
        void Update(Product product); void Delete(Product product);
        IEnumerable<Product> GetQueryableNoTracking();
        IEnumerable<Product> ApplyOrderByAndSearchFilter(IEnumerable<Product> Data, ProductOrderEnum? OrderBy, string? Search);
        Task<HttpStatusCode> CheckProductUpdate(Product product);

        Task<bool> ChangeQuantityAsync(int ProductId, int Amount, TransferDetectionType transferDetectionType, bool Save);


    }
}
