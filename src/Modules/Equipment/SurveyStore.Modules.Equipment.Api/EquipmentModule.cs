using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using SurveyStore.Modules.Equipment.Core;

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
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
