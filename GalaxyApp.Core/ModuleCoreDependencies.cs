using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GalaxyApp.Core
{
    public static class ModuleCoreDependencies
    {

        public static IServiceCollection AddCoreDependencies(this IServiceCollection Service)
        {
            // Mediator
            Service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Auto Mapper
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());


            Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            Service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));



            return Service;

        }

    }
}
