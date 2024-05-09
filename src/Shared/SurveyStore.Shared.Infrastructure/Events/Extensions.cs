using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Infrastructure.Postgres.Decorators;

namespace SurveyStore.Shared.Infrastructure.Events
{
    internal static class Extensions
    {
        public static IServiceCollection AddEvents(this IServiceCollection services, IList<Assembly> assemblies)
        {
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            services.Scan(a => a.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>))
                    .WithoutAttribute<DecoratorAttribute>())                   
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
