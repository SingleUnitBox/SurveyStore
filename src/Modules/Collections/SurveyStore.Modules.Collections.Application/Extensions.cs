using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Application.Policies;
using SurveyStore.Modules.Collections.Application.Services;

namespace SurveyStore.Modules.Collections.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IEventMapper, EventMapper>();
            services.AddSingleton<IFreeCollectionRemovalPolicy, FreeCollectionRemovalPolicy>();

            return services;
        }
    }
}
