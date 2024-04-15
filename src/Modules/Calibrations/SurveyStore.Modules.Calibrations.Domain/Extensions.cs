using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("SurveyStore.Modules.Calibrations.Api")]
namespace SurveyStore.Modules.Calibrations.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
