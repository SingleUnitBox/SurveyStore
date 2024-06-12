using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Payments.Application.Clients.SurveyJobs;
using SurveyStore.Modules.Payments.Infrastructure.Clients.SurveyJobs;

namespace SurveyStore.Modules.Payments.Infrastructure.Clients
{
    public static class Extensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services.AddSingleton<ISurveyJobsApiClient, SurveyJobApiClient>();

            return services;
        }
    }
}