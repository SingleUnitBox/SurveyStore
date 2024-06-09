using Microsoft.Extensions.DependencyInjection;

namespace SurveyStore.Modules.SurveyJobs.Domain.Policies
{
    public static class Extensions
    {
        public static IServiceCollection AddPolicies(this IServiceCollection services)
        {
            services.AddSingleton<ISurveyJobAssigningPolicy, SurveyJobAssigningPolicy>();

            return services;
        }
    }
}
