using GalaxyApp.Data.Entities.TransferDetectionFolder;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ITransferDetectionItemsRepo
    {
        Task<int> AddAsync(TransferDetectionItems TransferDetectionItem);

    }
}
