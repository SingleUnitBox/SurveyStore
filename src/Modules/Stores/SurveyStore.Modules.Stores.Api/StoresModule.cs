using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Stores.Core;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Stores.Api
{
    internal class StoresModule : IModule
    {
        public const string BasePath = "stores-module";
        public string Name { get; } = "Stores";
        public string Path => BasePath;
        public IEnumerable<string> Policies = new[]
        {
            "stores"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
