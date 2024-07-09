using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers;
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
            //correct
            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentHandler>();
            //services.Decorate<ICommandHandler<AddDocument>, AddDocumentLoggerDecorator>();
            //services.Decorate<ICommandHandler<AddDocument>, AddDocumentOuterLoggerDecorator>();

            //incorrect
            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentHandler>();
            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentLoggerDecorator>();
            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentOuterLoggerDecorator>();

            //incorrect
            //services.AddScoped<AddDocumentHandler>();
            //services.AddScoped<AddDocumentLoggerDecorator>();
            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentOuterLoggerDecorator>();

            //services.AddScoped<ICommandHandler<AddDocument>, AddDocumentHandler>();
            //looks like registration is not required
            //services.AddScoped(typeof(IGenericOuterLoggerDecorator<>), typeof(GenericOuterLoggerDecorator<>));
            services.Decorate<ICommandHandler<AddDocument>, AddDocumentLoggerDecorator>();
            //services.Decorate(typeof(ICommandHandler<>), typeof(GenericOuterLoggerDecorator<>));

            return services;
        }
    }
}
