using GalaxyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasOne(P => P.Supplier)
                .WithMany(S => S.Purchases)
                .HasForeignKey(P => P.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
