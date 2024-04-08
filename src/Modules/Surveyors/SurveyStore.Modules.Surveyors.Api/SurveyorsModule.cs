using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Surveyors.Core;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using SurveyStore.Modules.Surveyors.Core.DAL.Queries;
using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using SurveyStore.Shared.Infrastructure.Modules;

namespace SurveyStore.Modules.Surveyors.Api
{
    internal class SurveyorsModule : IModule
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
            app.UseModuleRequests()
                .Subscribe<GetSurveyorByEmail, SurveyorDto>("surveyors/get",
                    (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));
        }
    }
}
