using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
namespace SurveyStore.Modules.SurveyJobs.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddDocument>, AddDocumentLoggerDecorator>();

            return services;
        }
    }
}
