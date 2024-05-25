using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
namespace SurveyStore.Modules.SurveyJobs.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services)
        {
            services.AddPostgres<SurveyJobsDbContext>();
            services.AddScoped<ISurveyorRepository, PostgresSurveyorRepository>();
            services.AddScoped<IDocumentRepository, PostgresDocumentRepository>();
            services.AddScoped<ISurveyJobRepository, PostgresSurveyJobRepository>();

            return services;
        }
    }
}
