using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core
{
    public static  class ModuleCoreDependencies
    {

        public static IServiceCollection AddCoreDependencies(this IServiceCollection Service) {

            Service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return Service;

        }

    }
}
