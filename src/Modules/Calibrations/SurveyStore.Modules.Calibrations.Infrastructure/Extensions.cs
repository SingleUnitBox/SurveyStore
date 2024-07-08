using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Modules.Calibrations.Infrastructure.EF;
using SurveyStore.Modules.Calibrations.Infrastructure.EF.Repositories;
using SurveyStore.Modules.Calibrations.Infrastructure.Services;
using SurveyStore.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Calibrations.Api")]
namespace SurveyStore.Modules.Calibrations.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<CalibrationsDbContext>();
            services.AddScoped<ISurveyEquipmentRepository, PostgresSurveyEquipmentRepository>();
            services.AddScoped<ICalibrationsRepository, PostgresCalibrationsRepository>();
            //services.AddHostedService<CalibrationsDueBackgroundService>();

            return services;
        }
    }
}
