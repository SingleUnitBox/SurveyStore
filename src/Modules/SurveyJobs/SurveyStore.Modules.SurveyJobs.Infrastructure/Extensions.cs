using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Modules.SurveyJobs.Infrastructure.Clients;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Repositories;
using SurveyStore.Modules.SurveyJobs.Infrastructure.Middlewares;
using SurveyStore.Shared.Infrastructure.Postgres;
using SurveyStore.Shared.Infrastructure.Exceptions;
using System.Runtime.CompilerServices;
using SurveyStore.Shared.Infrastructure.Modules;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
namespace SurveyStore.Modules.SurveyJobs.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<SurveyJobsDbContext>();
            services.AddScoped<ISurveyorRepository, PostgresSurveyorRepository>();
            services.AddScoped<IDocumentRepository, PostgresDocumentRepository>();
            services.AddScoped<ISurveyJobRepository, PostgresSurveyJobRepository>();
            services.AddApiClients();
            services.AddSurveyJobsMiddlewares();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.Map("/jobs-module", app =>
            {
                app.UseErrorHandling();
                app.UseRouting();
                app.UseSurveyJobsMiddlewares();
                app.UseSurveyJobsBranchingMiddleware();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    //endpoints.MapGet("/", context
                    //    => context.Response.WriteAsync("SurveyStore API"));
                    //endpoints.MapModuleInfo();
                });
            });

            return app;
        }
    }
}
