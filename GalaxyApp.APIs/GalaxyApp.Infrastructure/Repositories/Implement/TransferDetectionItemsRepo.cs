using GalaxyApp.Data.Entities.TransferDetectionFolder;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class TransferDetectionItemsRepo : ITransferDetectionItemsRepo
    {
        private readonly GalaxyDbContext _galaxyDb;

        public TransferDetectionItemsRepo(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }

        public async Task<int> AddAsync(TransferDetectionItems TransferDetectionItem)
        {
            await _galaxyDb.transferDetectionItems.AddAsync(TransferDetectionItem);
            await _galaxyDb.SaveChangesAsync();

            int TDIId = (await _galaxyDb.transferDetectionItems.OrderByDescending(x => x.Id).FirstOrDefaultAsync()).Id;
            return TDIId;

        }
    }
}
