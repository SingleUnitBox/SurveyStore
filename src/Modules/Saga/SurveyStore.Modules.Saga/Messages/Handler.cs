using Chronicle;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga.Messages
{
    internal class Handler : IEventHandler<UserCreated>, IEventHandler<SurveyorCreated>, IEventHandler<StoreCreated>
    {
        private readonly ISagaCoordinator _coordinator;

        public Handler(ISagaCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public Task HandleAsync(UserCreated @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(SurveyorCreated @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(StoreCreated @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}
