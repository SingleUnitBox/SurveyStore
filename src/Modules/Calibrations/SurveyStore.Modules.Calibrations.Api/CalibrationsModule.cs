using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Calibrations.Application;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Modules.Calibrations.Domain;
using SurveyStore.Modules.Calibrations.Infrastructure;
using SurveyStore.Shared.Abstractions.Modules;
using SurveyStore.Shared.Abstractions.Queries;
using SurveyStore.Shared.Infrastructure.Modules;
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
            app.UseModuleRequests()
                .Subscribe<GetCalibrationBySerialNumber, CalibrationDto>("calibrations/get",
                    (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));
        }
    }
}
