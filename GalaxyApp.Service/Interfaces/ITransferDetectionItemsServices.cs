using GalaxyApp.Data.Entities.TransferDetectionFolder;

namespace GalaxyApp.Service.Interfaces
{
    public interface ITransferDetectionItemsServices
    {

        Task<int> AddAsync(TransferDetectionItems transferDetectionItems);

    }
}
