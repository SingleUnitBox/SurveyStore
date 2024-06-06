using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Decorators.Commands
{
    public class GenericOuterLoggerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly ILogger<GenericOuterLoggerDecorator<TCommand>> _logger;

        public GenericOuterLoggerDecorator(ICommandHandler<TCommand> commandHandler,
            ILogger<GenericOuterLoggerDecorator<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command)
        {
            await _commandHandler.HandleAsync(command);
            _logger.LogInformation($"Command handler with name {command.GetType().Name} has been activated. - generic outer logger.");
        }
    }
}
