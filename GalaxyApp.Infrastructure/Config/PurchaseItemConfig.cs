using GalaxyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    public class PurchaseItemConfig : IEntityTypeConfiguration<PurchaseItems>
    {
        public void Configure(EntityTypeBuilder<PurchaseItems> builder)
        {
            builder.HasOne(PI => PI.ItemProduct)
                .WithMany()
                .HasForeignKey(PI => PI.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(PI => PI.Purchase)
               .WithMany(P => P.PurchaseItems)
               .HasForeignKey(PI => PI.PurchaseId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
