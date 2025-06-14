using GalaxyApp.Data.Entities.TransferDetectionFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    public class TransferDetectionItemsConfig : IEntityTypeConfiguration<TransferDetectionItems>
    {
        public void Configure(EntityTypeBuilder<TransferDetectionItems> builder)
        {
            builder.HasOne(TDI => TDI.Product)
                .WithMany()
                .HasForeignKey(TDI => TDI.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(TDI => TDI.transferDetection)
                .WithMany()
                .HasForeignKey(TDI => TDI.TransferDetectionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
