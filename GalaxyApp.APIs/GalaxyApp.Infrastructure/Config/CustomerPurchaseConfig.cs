using GalaxyApp.Data.Entities.CustomerFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.Infrastructure.Config
{
    public class CustomerPurchaseConfig : IEntityTypeConfiguration<CustomerPurchase>
    {
        public void Configure(EntityTypeBuilder<CustomerPurchase> builder)
        {
            builder.HasOne(CP => CP.Customer)
                .WithMany(C => C.customerPurchases)
                .HasForeignKey(CP => CP.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
