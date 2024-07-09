using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Modules.Saga
{
    public class SagaModule : IModule
    {
        public const string BasePath = "saga-module";
        public string Name { get; } = "Saga";

        public string Path => BasePath;

        public void Register(IServiceCollection services)
        {
            services.AddSaga();
        }

        public void Use(IApplicationBuilder app)
        {

        }
    }
}
