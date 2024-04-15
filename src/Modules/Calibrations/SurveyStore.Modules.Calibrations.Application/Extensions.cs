using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Calibrations.Api")]
namespace SurveyStore.Modules.Calibrations.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
