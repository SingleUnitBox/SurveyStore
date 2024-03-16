using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Surveyors.Domain;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;

namespace SurveyStore.Modules.Surveyors.Api
{
    public class SurveyorsModule : IModule
    {
        public const string BasePath = "surveyors-module";
        public string Name { get; } = "Surveyors";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "surveyors",
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
