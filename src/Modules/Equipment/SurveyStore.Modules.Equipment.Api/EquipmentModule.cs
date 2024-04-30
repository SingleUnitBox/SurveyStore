using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Equipment.Application;
using SurveyStore.Modules.Equipment.Domain;
using SurveyStore.Modules.Equipment.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;

namespace SurveyStore.Modules.Equipment.Api
{
    public class EquipmentModule : IModule
    {
        public const string BasePath = "equipment-module";
        public string Name { get; } = "Equipment";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "equipment"
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
