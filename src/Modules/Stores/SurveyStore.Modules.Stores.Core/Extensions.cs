using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Stores.Core.DAL;
using SurveyStore.Modules.Stores.Core.DAL.Repositories;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Modules.Stores.Core.Services;
using SurveyStore.Shared.Infrastructure.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<StoresDbContext>();
            services.AddScoped<IStoreRepository, PostgresStoreRepository>();
            services.AddScoped<IStoreService, StoreService>();

            return services;
        }
    }
}
