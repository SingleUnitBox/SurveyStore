using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Equipment.Domain.Kit.Repositories;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories;
using SurveyStore.Modules.Equipment.Infrastructure.EF;
using SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Equipment.Api")]
namespace SurveyStore.Modules.Equipment.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<EquipmentDbContext>();
            services.AddScoped<ISurveyEquipmentRepository, PostgresSurveyEquipmentRepository>();
            services.AddScoped<IKitRepository, PostgresKitRepository>();

            return services;
        }
    }
}
