using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    internal static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
            //services.AddScoped<SurveyStoreCustomErrorHandlerMiddleware>();
            //services.AddSingleton<ICustomErrorMapper, CustomErrorMapper>();

            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
            services.AddSingleton<IExceptionCompositionRoot, ExceptionCompositionRoot>();

            return services;
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            //app.UseMiddleware<SurveyStoreCustomErrorHandlerMiddleware>();

            return app;
        }
    }
}
