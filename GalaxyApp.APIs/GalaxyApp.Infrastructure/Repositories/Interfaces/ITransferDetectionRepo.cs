using GalaxyApp.Data.Entities.TransferDetectionFolder;

namespace GalaxyApp.Infrastructure.Repositories.Interfaces
{
    public interface ITransferDetectionRepo
    {

        Task<int> AddAsync(TransferDetection transferDetection);
        Task UpdateAsync(TransferDetection transferDetection);

    }
}
