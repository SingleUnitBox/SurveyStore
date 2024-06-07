using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Application;
using SurveyStore.Modules.SurveyJobs.Domain;
using SurveyStore.Modules.SurveyJobs.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Api
{
    public class SurveyJobsModule : IModule
    {
        public const string BasePath = "jobs-module";
        public string Name { get; } = "Survey Jobs";
        public string Path => BasePath;
        public IEnumerable<string> Policies { get; } = new[]
        {
            "jobs"
        };

        public void Register(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
        }

        public void Use(IApplicationBuilder app)
        {
            app.UseInfrastructure();
        }
    }
}
