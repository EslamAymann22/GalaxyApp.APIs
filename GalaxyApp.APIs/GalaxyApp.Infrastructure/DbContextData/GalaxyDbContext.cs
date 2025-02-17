using GalaxyApp.Data.Entities;
using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure.DbContextData
{
    public class GalaxyDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerInvoice> customerInvoices{ get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Supplier> suppliers { get; set; }

        public GalaxyDbContext (DbContextOptions<GalaxyDbContext> Options) : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }




    }
}
