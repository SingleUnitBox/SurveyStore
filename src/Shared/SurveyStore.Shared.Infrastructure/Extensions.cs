using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Infrastructure.Api;
using SurveyStore.Shared.Infrastructure.Exceptions;
using SurveyStore.Shared.Infrastructure.Services;
using SurveyStore.Shared.Infrastructure.Time;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Bootstrapper")]
namespace SurveyStore.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            services.AddSingleton<IClock, ClockUtc>();
            services.AddErrorHandling();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            app.UseRouting();

            return app;
        }

        public static TOptions GetOptions<TOptions>(this IServiceCollection services, string sectionName)
            where TOptions : class, new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                return configuration.GetOptions<TOptions>(sectionName);
            }
        }

        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : class, new()
        {
            var options = new TOptions();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
