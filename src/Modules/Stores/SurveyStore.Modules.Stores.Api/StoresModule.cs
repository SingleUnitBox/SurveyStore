using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Stores.Core;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using SurveyStore.Modules.Stores.Core.DAL.Queries;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using SurveyStore.Shared.Infrastructure.Modules;

namespace SurveyStore.Modules.Stores.Api
{
    internal class StoresModule : IModule
    {
        public const string BasePath = "stores-module";
        public string Name { get; } = "Stores";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "stores"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            app.UseModuleRequests()
                .Subscribe<GetStoreById, StoreDto>("stores/get",
                    (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));
        }
    }
}
