using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Application.Clients.Surveyors;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Modules.Collections.Infrastructure.Clients;
using SurveyStore.Modules.Collections.Infrastructure.EF;
using SurveyStore.Modules.Collections.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;

namespace SurveyStore.Modules.Collections.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<CollectionsDbContext>();
            services.AddScoped<IStoreRepository, PostgresStoreRepository>();
            services.AddScoped<ISurveyEquipmentRepository, PostgresSurveyEquipmentRepository>();
            services.AddScoped<ISurveyorRepository, PostgresSurveyorRepository>();
            services.AddScoped<ICollectionRepository, PostgresCollectionRepository>();

            services.AddApiClients();
            services.AddUnitOfWork<ICollectionsUnitOfWork, CollectionsUnitOfWork>();

            return services;
        }
    }
}
