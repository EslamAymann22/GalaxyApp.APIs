using GalaxyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.Property(P=>P.ShopQuantity).HasDefaultValue(0);
            //builder.Property(P=>P.WarehouseQuantity).HasDefaultValue(0);
            //builder.Property(P=>P.Discount).HasDefaultValue(0);
        }
    }
}
