using GalaxyApp.Data.Entities.TransferDetectionFolder;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class TransferDetectionServices : ITransferDetectionServices
    {
        private readonly ITransferDetectionRepo _transferDetectionRepo;

        public TransferDetectionServices(ITransferDetectionRepo transferDetectionRepo)
        {
            this._transferDetectionRepo = transferDetectionRepo;
        }
        public async Task<int> AddAsync(TransferDetection transferDetection)
        => await _transferDetectionRepo.AddAsync(transferDetection);

        public async Task UpdateAsync(TransferDetection transferDetection)
        => await _transferDetectionRepo.UpdateAsync(transferDetection);
    }
}
