using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Domain.Policies;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
namespace SurveyStore.Modules.SurveyJobs.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddPolicies();

            return services;
        }
    }
}
