using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Kernel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Kernel
{
    internal class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(params IDomainEvent[] events)
        {
            if (events is null || !events.Any())
            {
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            {
                foreach (var domainEvent in events)
                {
                    var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                    var handlers = scope.ServiceProvider.GetServices(handlerType);

                    var tasks = handlers.Select(h => (Task)handlerType
                        .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                        ?.Invoke(h, new[] { domainEvent }));

                    await Task.WhenAll(tasks);
                }
            }
        }
    }
}
