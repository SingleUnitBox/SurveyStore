using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.Middlewares
{
    internal static class Extensions
    {
        public static IServiceCollection AddSurveyJobsMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<SurveyJobsOuterLoggingMiddleware>();
            services.AddScoped<SurveyJobsInnerLoggingMiddleware>();
            //services.AddScoped<SurveyJobsBranchingMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseSurveyJobsMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<SurveyJobsOuterLoggingMiddleware>();
            app.UseMiddleware<SurveyJobsInnerLoggingMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseSurveyJobsBranchingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SurveyJobsBranchingMiddleware>();

            return app;
        }
    }
}
