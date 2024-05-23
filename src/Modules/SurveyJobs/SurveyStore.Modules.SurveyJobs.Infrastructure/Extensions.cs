using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
namespace SurveyStore.Modules.SurveyJobs.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services)
        {
            return services;
        }
    }
}
