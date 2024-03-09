using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Shared.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if (command is null)
            {
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            {
                var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

                await commandHandler.HandleAsync(command);
            }
        }
    }
}
