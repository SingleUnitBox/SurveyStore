using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using SurveyStore.Modules.Surveyors.Core.DAL;
using SurveyStore.Modules.Surveyors.Core.DAL.Repositories;
using SurveyStore.Modules.Surveyors.Core.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Surveyors.Api")]
namespace SurveyStore.Modules.Surveyors.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<SurveyorDbContext>();
            services.AddScoped<ISurveyorRepository, PostgresSurveyorRepository>();

            return services;
        }
    }
}
