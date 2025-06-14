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
            Service.AddScoped<ICustomerRepo, CustomerRepo>();
            Service.AddScoped<IPurchaseItemRepo, PurchaseItemRepo>();
            Service.AddScoped<ICustomerPurchaseRepo, CustomerPurchaseRepo>();
            Service.AddScoped<ITransferDetectionRepo, TransferDetectionRepo>();
            Service.AddScoped<ICustomerPurchaseItemsRepo, CustomerPurchaseItemsRepo>();
            Service.AddScoped<ITransferDetectionItemsRepo, TransferDetectionItemsRepo>();

            return Service;

        }

    }
}
