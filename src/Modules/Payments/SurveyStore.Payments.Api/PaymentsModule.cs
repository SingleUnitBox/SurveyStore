using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Payments.Application;
using SurveyStore.Modules.Payments.Domain;
using SurveyStore.Modules.Payments.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;

namespace SurveyStore.Modules.Payments.Api
{
    public class PaymentsModule : IModule
    {
        public const string BasePath = "payments-module";
        public string Name { get; } = "Payments";

        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "payments",
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
