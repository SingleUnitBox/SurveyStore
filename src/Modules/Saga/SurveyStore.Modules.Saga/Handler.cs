using Chronicle;
using SurveyStore.Modules.Saga.Messages;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga
{
    internal class Handler : IEventHandler<CalibrationUpdated>, IEventHandler<CollectionReturnedDueCalibration>, IEventHandler<CalibrationRenewed>
    {
        private readonly ISagaCoordinator _sagaCoordinator;

        public Handler(ISagaCoordinator sagaCoordinator)
        {
            _sagaCoordinator = sagaCoordinator;
        }

        public Task HandleAsync(CalibrationUpdated @event)
            => _sagaCoordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(CollectionReturnedDueCalibration @event)
            => _sagaCoordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(CalibrationRenewed @event)
            => _sagaCoordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}
