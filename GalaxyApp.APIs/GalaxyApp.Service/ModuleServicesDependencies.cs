using GalaxyApp.Service.Implement;
using GalaxyApp.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GalaxyApp.Infrastructure
{
    public static class ModuleServicesDependencies
    {

        public static IServiceCollection AddServicesDependencies(this IServiceCollection Service)
        {
            Service.AddScoped<IProductService, ProductService>();
            Service.AddScoped<ISupplierService, SupplierService>();
            Service.AddScoped<IPurchaseService, PurchaseService>();
            Service.AddScoped<ICustomerServices, CustomerServices>();
            Service.AddScoped<IPurchaseItemService, PurchaseItemService>();
            Service.AddScoped<ITransferDetectionServices, TransferDetectionServices>();
            Service.AddScoped<ITransferDetectionItemsServices, TransferDetectionItemsServices>();

            return Service;

        }

    }
}
