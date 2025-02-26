using GalaxyApp.Data.Entities;
using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Data.Entities.Identity;
using GalaxyApp.Data.Entities.TransferDetectionFolder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GalaxyApp.Infrastructure.DbContextData
{
    public class GalaxyDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerPurchase> customerPurchases { get; set; }
        public DbSet<CustomerPurchaseItem> customerPurchaseItems { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<PurchaseItems> purchaseItems { get; set; }
        public DbSet<TransferDetection> transferDetections { get; set; }
        public DbSet<TransferDetectionItems> transferDetectionItems { get; set; }


        public GalaxyDbContext(DbContextOptions<GalaxyDbContext> Options) : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }




    }
}
