using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Shared.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
