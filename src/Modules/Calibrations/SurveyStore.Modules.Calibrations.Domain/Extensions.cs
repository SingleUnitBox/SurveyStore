using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Calibrations.Domain.DomainServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("SurveyStore.Modules.Calibrations.Api")]
namespace SurveyStore.Modules.Calibrations.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<ICalibrationService, CalibrationService>();

            return services;
        }
    }
}
