using GalaxyApp.Infrastructure.Repositories.Implement;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Implement.ProductImp;
using GalaxyApp.Service.Interfaces.ProductInterface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure
{
    public static class ModuleServicesDependencies
    {

        public static IServiceCollection AddServicesDependencies (this IServiceCollection Service)
        {
            Service.AddScoped<IProductService, ProductService>();

            return Service;

        }

    }
}
