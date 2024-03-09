using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Modules.Equipment.Infrastructure.EF;
using SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Equipment.Api")]
namespace SurveyStore.Modules.Equipment.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<EquipmentDbContext>();
            services.AddScoped<ISurveyEquipmentRepository, PostgresSurveyEquipmentRepository>();

            return services;
        }
    }
}
