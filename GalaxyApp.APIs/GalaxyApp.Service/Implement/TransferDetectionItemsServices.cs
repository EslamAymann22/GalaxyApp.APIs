using GalaxyApp.Data.Entities.TransferDetectionFolder;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Service.Implement
{
    public class TransferDetectionItemsServices : ITransferDetectionItemsServices
    {
        private readonly ITransferDetectionItemsRepo _transferDetectionItemsRepo;

        public TransferDetectionItemsServices(ITransferDetectionItemsRepo transferDetectionItemsRepo)
        {
            this._transferDetectionItemsRepo = transferDetectionItemsRepo;
        }


        public Task<int> AddAsync(TransferDetectionItems transferDetectionItems)
        => _transferDetectionItemsRepo.AddAsync(transferDetectionItems);
    }
}
