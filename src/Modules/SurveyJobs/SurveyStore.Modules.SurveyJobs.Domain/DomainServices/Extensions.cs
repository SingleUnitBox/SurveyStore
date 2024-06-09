using Microsoft.Extensions.DependencyInjection;

namespace SurveyStore.Modules.SurveyJobs.Domain.DomainServices
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<ISurveyJobsDomainService, SurveyJobsDomainService>();

            return services;
        }
    }
}
