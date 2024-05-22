using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Application.Clients.Surveyors;
using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Infrastructure.Clients;
using SurveyStore.Modules.Collections.Infrastructure.EF;
using SurveyStore.Modules.Collections.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure;
using SurveyStore.Shared.Infrastructure.Postgres;

namespace SurveyStore.Modules.Collections.Infrastructure
{
    public static class Extensions
    {
        private const string kitSectionName = "kitConst";
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<CollectionsDbContext>();
            services.AddScoped<IStoreRepository, PostgresStoreRepository>();
            services.AddScoped<ISurveyEquipmentRepository, PostgresSurveyEquipmentRepository>();
            services.AddScoped<IKitRepository, PostgresKitRepository>();
            services.AddScoped<ISurveyorRepository, PostgresSurveyorRepository>();
            services.AddScoped<ICollectionRepository, PostgresCollectionRepository>();
            services.AddScoped<IKitCollectionRepository, PostgresKitCollectionRepository>();
            var kitConstOptions = services.GetOptions<KitConstOptions>(kitSectionName);
            services.AddSingleton(kitConstOptions);

            services.AddApiClients();
            services.AddUnitOfWork<ICollectionsUnitOfWork, CollectionsUnitOfWork>();

            return services;
        }
    }
}
