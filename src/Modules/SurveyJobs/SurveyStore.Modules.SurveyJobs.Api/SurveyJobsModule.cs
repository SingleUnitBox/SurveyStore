using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Modules.SurveyJobs.Api
{
    public class SurveyJobsModule : IModule
    {
        public string Name => throw new System.NotImplementedException();

        public string Path => throw new System.NotImplementedException();

        public void Register(IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }

        public void Use(IApplicationBuilder app)
        {
            throw new System.NotImplementedException();
        }
    }
}
