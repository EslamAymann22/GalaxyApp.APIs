using GalaxyApp.Data.Entities;
using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Data.Entities.Identity;
using GalaxyApp.Infrastructure.DbContextData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Infrastructure.DataSeeding
{
    public static class DataSeed
    {

        public static async Task AddDataSeedAsync(GalaxyDbContext galaxyDb, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            await AddRolesAsync(roleManager);
            await AddProductsAsync(galaxyDb);
            await AddSuppliersAsync(galaxyDb);
            await AddCustomersAsync(galaxyDb);
        }

        public static async Task AddRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.Roles.AnyAsync()) return;
            foreach (var role in Enum.GetValues<UserRole>())
            {
                var roleName = role.ToString();
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        public static async Task AddProductsAsync(GalaxyDbContext galaxyDb)
        {
            if (await galaxyDb.products.AnyAsync()) return;

            await galaxyDb.products.AddRangeAsync(
            new Product
            {
                Color = "Red",
                Name = "IPhone",
                PurchasingPrice = 1000.00M,
                sellingPrice = 800.00M,
                Discount = 0.10M,
                Evaluation = 4,
                ShopQuantity = 50,
                WarehouseQuantity = 100
            },
            new Product
            {
                Color = "Black",
                Name = "Samsung Galaxy",
                PurchasingPrice = 900.00M,
                sellingPrice = 750.00M,
                Discount = 0.05M,
                Evaluation = 5,
                ShopQuantity = 30,
                WarehouseQuantity = 80
            },
            new Product
            {
                Color = "Silver",
                Name = "Google Pixel",
                PurchasingPrice = 800.00M,
                sellingPrice = 700.00M,
                Discount = 0.15M,
                Evaluation = 3,
                ShopQuantity = 20,
                WarehouseQuantity = 60
            },
            new Product
            {
                Color = "Blue",
                Name = "OnePlus",
                PurchasingPrice = 7000.00M,
                sellingPrice = 6500.00M,
                Discount = 0.20M,
                Evaluation = 4,
                ShopQuantity = 25,
                WarehouseQuantity = 70
            },
            new Product
            {
                Color = "White",
                Name = "Xiaomi",
                PurchasingPrice = 600.00M,
                sellingPrice = 550.00M,
                Discount = 0.12M,
                Evaluation = 4,
                ShopQuantity = 40,
                WarehouseQuantity = 90
            }
            );
            await galaxyDb.SaveChangesAsync();
        }
        public static async Task AddSuppliersAsync(GalaxyDbContext galaxyDb)
        {
            if (await galaxyDb.suppliers.AnyAsync()) return;
            await galaxyDb.suppliers.AddRangeAsync(
                new Supplier { Name = "Apple" },
                new Supplier { Name = "Samsung" },
                new Supplier { Name = "Google" },
                new Supplier { Name = "OnePlus" },
                new Supplier { Name = "Xiaomi" },
                new Supplier { Name = "Huawei" }
            );
            await galaxyDb.SaveChangesAsync();
        }

        public static async Task AddCustomersAsync(GalaxyDbContext galaxyDb)
        {
            if (await galaxyDb.customers.AnyAsync()) return;
            await galaxyDb.AddRangeAsync(
                new Customer { Name = "Eslam", Phone = "01277296213" },
                new Customer { Name = "Ahmed", Phone = "01012345678" },
                new Customer { Name = "Sara", Phone = "01123456789" },
                new Customer { Name = "Mona", Phone = "01234567890" },
                new Customer { Name = "Ali", Phone = "01567890123" },
                new Customer { Name = "Omar", Phone = "01678901234" },
                new Customer { Name = "Fatma", Phone = "01789012345" }
                );
            await galaxyDb.SaveChangesAsync();
        }

    }

}
