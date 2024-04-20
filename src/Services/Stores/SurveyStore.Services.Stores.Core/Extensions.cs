using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Services.Stores.Core.DAL;
using SurveyStore.Services.Stores.Core.DAL.Repositories;
using SurveyStore.Services.Stores.Core.Repositories;
using SurveyStore.Services.Stores.Core.Services;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Infrastructure.Services;
using SurveyStore.Shared.Infrastructure.Time;
using SurveyStore.Shared.Infrastructure.Auth;
using SurveyStore.Shared.Infrastructure.Events;
using SurveyStore.Shared.Infrastructure.Contexts;
using SurveyStore.Shared.Infrastructure.Commands;
using SurveyStore.Shared.Infrastructure.Queries;
using SurveyStore.Shared.Infrastructure.Postgres;
using SurveyStore.Shared.Infrastructure.Exceptions;
using SurveyStore.Shared.Infrastructure.Kernel;
using SurveyStore.Shared.Infrastructure.Modules;
using SurveyStore.Shared.Infrastructure.Messaging;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Services.Stores.Api")]
namespace SurveyStore.Services.Stores.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.AddPostgres<StoresDbContext>();
            services.AddScoped<IStoreRepository, PostgresStoreRepository>();
            services.AddScoped<IStoreService, StoreService>();           
            services.AddAuth();
            services.AddEvents(assemblies);
            services.AddCommands(assemblies);
            services.AddQueries(assemblies);            
            services.AddDomainEvents(assemblies);
            services.AddContexts();           
            services.AddModulesRequests(assemblies);
            services.AddMessaging();
            services.AddPostgres();
            services.AddTransactionalDecorators();
            services.AddHostedService<AppInitializer>();
            services.AddSingleton<IClock, ClockUtc>();
            services.AddErrorHandling();
            services.AddControllers();

            return services;
        }
    }
}
