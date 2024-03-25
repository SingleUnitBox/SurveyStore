using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;
using SurveyStore.Modules.Collections.Application;
using SurveyStore.Modules.Collections.Core;
using SurveyStore.Modules.Collections.Infrastructure;

namespace SurveyStore.Modules.Collections.Api
{
    public class CollectionsModule : IModule
    {
        public const string BasePath = "collections-module";
        public string Name { get; } = "Collections";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "collections",
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
            services.AddApplication();
            services.AddInfrastructure();
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
