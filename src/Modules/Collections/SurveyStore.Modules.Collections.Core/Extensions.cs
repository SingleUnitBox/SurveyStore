using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Core.DomainServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Collections.Tests.Unit")]
namespace SurveyStore.Modules.Collections.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<ICollectionService, CollectionService>();

            return services;
        }
    }
}
