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
using System.Net.WebSockets;
using SurveyStore.Shared.Abstractions.Commands;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SurveyStore.Modules.Surveyors.Core.Commands;
using System.Threading.Tasks;

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
                .Subscribe<GetSurveyorById, SurveyorDto>("surveyors/get",
                    (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));
            //app.UseModuleRequests()
            //    .Subscribe<CreateSurveyor, Task>("surveyors/create",
            //        (command, sp) => sp.GetRequiredService<ICommandHandler<CreateSurveyor>>().HandleAsync(command));
            app.UseModuleRequests()
                .Subscribe<CreateSurveyor, object>("surveyors/backdoor/create",
                async (command, sp) =>
                {
                    var handler = sp.GetRequiredService<ICommandHandler<CreateSurveyor>>();
                    await handler.HandleAsync(command);

                    return null;
                });
        }
    }
}
