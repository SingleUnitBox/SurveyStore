using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Core.DomainServices;

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
