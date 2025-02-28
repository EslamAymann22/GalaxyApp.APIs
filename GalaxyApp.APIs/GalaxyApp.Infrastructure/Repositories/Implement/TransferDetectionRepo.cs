using GalaxyApp.Data.Entities.TransferDetectionFolder;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Infrastructure.Repositories.Interfaces;

namespace GalaxyApp.Infrastructure.Repositories.Implement
{
    public class TransferDetectionRepo : ITransferDetectionRepo
    {
        private readonly GalaxyDbContext _galaxyDb;

        public TransferDetectionRepo(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }


        public async Task<int> AddAsync(TransferDetection transferDetection)
        {
            await _galaxyDb.transferDetections.AddAsync(transferDetection);
            await _galaxyDb.SaveChangesAsync();
            int TDId = _galaxyDb.transferDetections.OrderByDescending(TD => TD.Id).FirstOrDefault().Id;
            return TDId;
        }

        public async Task UpdateAsync(TransferDetection transferDetection)
        {
            _galaxyDb.transferDetections.Update(transferDetection);
            await _galaxyDb.SaveChangesAsync();


        }
    }
}
