using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Infrastructure.Exceptions;
using SurveyStore.Shared.Infrastructure.Time;

namespace SurveyStore.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IClock, ClockUtc>();
            services.AddErrorHandling();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandling();

            return app;
        }
    }
}
