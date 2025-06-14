using GalaxyApp.Data.Entities.TransferDetectionFolder;

namespace GalaxyApp.Service.Interfaces
{
    public interface ITransferDetectionServices
    {

        Task<int> AddAsync(TransferDetection transferDetection);
        Task UpdateAsync(TransferDetection transferDetection);

    }
}
