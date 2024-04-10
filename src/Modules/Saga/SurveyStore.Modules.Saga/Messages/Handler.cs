using Chronicle;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga.Messages
{
    internal class Handler : IEventHandler<SignedUp>, IEventHandler<SignedIn>, IEventHandler<SurveyorCreated>
    {
        private readonly ISagaCoordinator _coordinator;

        public Handler(ISagaCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public Task HandleAsync(SurveyorCreated @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(SignedUp @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(SignedIn @event)
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}
