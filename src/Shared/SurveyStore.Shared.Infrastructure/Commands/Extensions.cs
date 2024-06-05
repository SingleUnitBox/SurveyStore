using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Commands;
using System.Collections.Generic;
using System.Reflection;
using SurveyStore.Shared.Infrastructure.Postgres.Decorators;

namespace SurveyStore.Shared.Infrastructure.Commands
{
    internal static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            //services.Scan(a => a.FromAssemblies(assemblies)
            //    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
            //        .WithoutAttribute<DecoratorAttribute>())
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

            return services;
        }
    }
}
