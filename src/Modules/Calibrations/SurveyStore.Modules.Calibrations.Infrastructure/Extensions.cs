using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Calibrations.Api")]
namespace SurveyStore.Modules.Calibrations.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
