using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Collections.Tests.Unit")]
namespace SurveyStore.Modules.Collections.Domain
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
