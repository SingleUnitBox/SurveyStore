using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Application.Policies;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class CalibrationUpdatedHandler : IEventHandler<CalibrationUpdated>
    {
        private readonly ICalibrationsApiClient _calibrationsApiClient;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IFreeCollectionRemovalPolicy _freeCollectionRemovalPolicy;
        private readonly IMessageBroker _messageBroker;
        public CalibrationUpdatedHandler(ICalibrationsApiClient calibrationsApiClient,
            ICollectionRepository collectionRepository,
            IFreeCollectionRemovalPolicy freeCollectionRemovalPolicy,
            IMessageBroker messageBroker)
        {
            _calibrationsApiClient = calibrationsApiClient;
            _collectionRepository = collectionRepository;
            _freeCollectionRemovalPolicy = freeCollectionRemovalPolicy;
            _messageBroker = messageBroker;
        }
        public async Task HandleAsync(CalibrationUpdated @event)
        {
            var calibration = await _calibrationsApiClient.GetCalibrationAsync(@event.SurveyEquipmentId);
            if (calibration is null)
            {
                return;
            }

            if (_freeCollectionRemovalPolicy.CanBeDeleted(calibration))
            {
                var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(calibration.SurveyEquipmentId);
                if (collection is not null)
                {
                    await _collectionRepository.DeleteAsync(collection);
                }
                else
                {
                    collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(@event.SurveyEquipmentId);
                    if (collection is not null)
                    {
                        //TODO inform surveyor to return equipment before calibrationDueDate
                        return;
                    }
                }
            }
        }
    }
}