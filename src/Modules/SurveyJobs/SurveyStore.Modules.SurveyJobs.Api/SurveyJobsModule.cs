using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Application;
using SurveyStore.Modules.SurveyJobs.Domain;
using SurveyStore.Modules.SurveyJobs.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using SurveyStore.Shared.Infrastructure.Modules;
using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;

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
            app.UseModuleRequests()
                .Subscribe<GetSurveyJobById, SurveyJobDto>("surveyJobs/get",
                (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));
        }
    }
}