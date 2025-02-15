using GalaxyApp.Infrastructure.Repositories.Implement;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies (this IServiceCollection Service)
        {
            Service.AddScoped<IProductRepo, ProductRepo>();

            return Service;

        }

    }
}
