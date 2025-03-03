using GalaxyApp.Data.Entities.CustomerFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    internal class CustomerPurchaseItemConfig : IEntityTypeConfiguration<CustomerPurchaseItem>
    {
        public void Configure(EntityTypeBuilder<CustomerPurchaseItem> builder)
        {
            builder.HasOne(CPI => CPI.Product)
                .WithMany()
                .HasForeignKey(CPI => CPI.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(CPI => CPI.CustomerPurchase)
                .WithMany()
                .HasForeignKey(CPI => CPI.CustomerPurchaseId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
