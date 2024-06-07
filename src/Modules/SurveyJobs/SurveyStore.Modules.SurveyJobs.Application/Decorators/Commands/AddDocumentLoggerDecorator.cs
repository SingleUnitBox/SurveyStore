using Microsoft.Extensions.Logging;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Infrastructure.Postgres.Decorators;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands
{
    [Decorator]
    internal sealed class AddDocumentLoggerDecorator : ICommandHandler<AddDocument>
    {
        private readonly ICommandHandler<AddDocument> _commandHandler;
        private readonly ILogger<AddDocumentLoggerDecorator> _logger;

        public AddDocumentLoggerDecorator(ICommandHandler<AddDocument> commandHandler,
            ILogger<AddDocumentLoggerDecorator> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(AddDocument command)
        {
            await _commandHandler.HandleAsync(command);
            _logger.LogInformation($"Document with id '{command.Id}' has been created. - logger decorator");
        }
    }
}
