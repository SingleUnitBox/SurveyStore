using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Infrastructure.Api;
using SurveyStore.Shared.Infrastructure.Auth;
using SurveyStore.Shared.Infrastructure.Exceptions;
using SurveyStore.Shared.Infrastructure.Services;
using SurveyStore.Shared.Infrastructure.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;
using SurveyStore.Shared.Infrastructure.Commands;
using SurveyStore.Shared.Infrastructure.Contexts;
using SurveyStore.Shared.Infrastructure.Events;
using SurveyStore.Shared.Infrastructure.Kernel;
using SurveyStore.Shared.Infrastructure.Messaging;
using SurveyStore.Shared.Infrastructure.Modules;
using SurveyStore.Shared.Infrastructure.Queries;

[assembly: InternalsVisibleTo("SurveyStore.Shared.Tests")]
[assembly: InternalsVisibleTo("SurveyStore.Modules.Users.Tests.Integration")]
[assembly: InternalsVisibleTo("SurveyStore.Modules.Stores.Tests.Unit")]
[assembly: InternalsVisibleTo("SurveyStore.Bootstrapper")]
namespace SurveyStore.Shared.Infrastructure
{
    internal static class Extensions
    {
        private const string CorsPolicy = "cors";
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IList<Assembly> assemblies,
            IList<IModule> modules)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy(CorsPolicy, x =>
                {
                    x.WithOrigins("*")
                        .WithMethods("POST", "PUT", "DELETE")
                        .WithHeaders("Content-Type", "Authorization");
                });
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.CustomSchemaIds(x => x.FullName);
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SurveyStore API",
                    Version = "v1",
                });
            });

            var disabledModules = new List<string>();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                    {
                        continue;
                    }

                    if (!bool.Parse(value))
                    {
                        disabledModules.Add(key.Split(":")[0]);
                    }
                }
            }

            services.AddCommands(assemblies);
            services.AddQueries(assemblies);
            services.AddEvents(assemblies);
            services.AddDomainEvents(assemblies);
            services.AddContexts();
            services.AddAuth(modules);
            services.AddModuleInfo(modules);
            services.AddModulesRequests(assemblies);
            services.AddMessaging();
            services.AddHostedService<AppInitializer>();
            services.AddSingleton<IClock, ClockUtc>();
            services.AddErrorHandling();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    var removedParts = new List<ApplicationPart>();
                    foreach (var disabledModule in disabledModules)
                    {
                        var parts = manager.ApplicationParts
                            .Where(x => x.Name.Contains(disabledModule, StringComparison.InvariantCultureIgnoreCase));
                        removedParts.AddRange(parts);
                    }

                    foreach (var removedPart in removedParts)
                    {
                        manager.ApplicationParts.Remove(removedPart);
                    }
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicy);
            app.UseErrorHandling();
            app.UseSwagger();
            app.UseReDoc(r =>
            {
                r.RoutePrefix = "docs";
                r.SpecUrl("/swagger/v1/swagger.json");
                r.DocumentTitle = "SurveyStore API";
            });
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

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
