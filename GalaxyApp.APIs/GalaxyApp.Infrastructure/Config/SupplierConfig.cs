using GalaxyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(S => S.LatestPurchaseId).IsRequired(false);

            builder.HasOne(S => S.LatestPurchase)
                .WithOne(P => P.SupplierLst)
                .HasForeignKey<Supplier>(S => S.LatestPurchaseId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(S => S.Purchases)
               .WithOne(P => P.Supplier)
               .HasForeignKey(S => S.SupplierId)
               .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
