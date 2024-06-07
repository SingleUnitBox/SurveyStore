using Microsoft.Extensions.Logging;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands
{
    internal sealed class AddDocumentOuterLoggerDecorator : ICommandHandler<AddDocument>
    {
        private readonly ICommandHandler<AddDocument> _commandHandler;
        private readonly ILogger<AddDocumentOuterLoggerDecorator> _logger;

        public AddDocumentOuterLoggerDecorator(ICommandHandler<AddDocument> commandHandler,
            ILogger<AddDocumentOuterLoggerDecorator> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(AddDocument command)
        {
            await _commandHandler.HandleAsync(command);
            _logger.LogInformation($"Document with id '{command.Id}' has been created. - outer logger decorator.");
        }
    }
}
