using GalaxyApp.Infrastructure.Repositories.Implement;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GalaxyApp.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection Service)
        {
            Service.AddScoped<IProductRepo, ProductRepo>();
            Service.AddScoped<ISupplierRepo, SupplierRepo>();
            Service.AddScoped<IPurchaseRepo, PurchaseRepo>();
            Service.AddScoped<IPurchaseItemRepo, PurchaseItemRepo>();

            return Service;

        }

    }
}
