using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SurveyStore.Shared.Infrastructure.Postgres.Decorators
{
    [Decorator]
    internal class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : class, ICommand
    {
        private readonly ICommandHandler<T> _handler;
        private readonly UnitOfWorkTypeRegistry _typeRegistry;
        private readonly IServiceProvider _serviceProvider;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler,
            UnitOfWorkTypeRegistry typeRegistry,
            IServiceProvider serviceProvider)
        {
            _handler = handler;
            _typeRegistry = typeRegistry;
            _serviceProvider = serviceProvider;
        }
        public async Task HandleAsync(T command)
        {
            var unitOfWorkType = _typeRegistry.Resolve<T>();
            if (unitOfWorkType is null)
            {
                await _handler.HandleAsync(command);
                return;
            }

            var unitOfWork = (IUnitOfWork)_serviceProvider.GetRequiredService(unitOfWorkType);
            await unitOfWork.ExecuteAsync(() => _handler.HandleAsync(command));
        }
    }
}
