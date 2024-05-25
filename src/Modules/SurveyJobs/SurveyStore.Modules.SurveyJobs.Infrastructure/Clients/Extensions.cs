using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.Clients
{
    public static class Extensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services.AddSingleton<ISurveyorsApiClient, SurveyorsApiClient>();

            return services;
        }
    }
}
