using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Calibrations.Application;
using SurveyStore.Modules.Calibrations.Domain;
using SurveyStore.Modules.Calibrations.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;

namespace SurveyStore.Modules.Calibrations.Api
{
    public class CalibrationsModule : IModule
    {
        public const string BasePath = "calibrations-module";
        public string Name { get; } = "Calibrations";
        public string Path => BasePath;
        public IEnumerable<string> Policies { get; } = new[]
        {
            "calibrations",
        };
        public void Register(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
