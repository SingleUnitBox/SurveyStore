using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class CalibrationUpdatedHandler : IEventHandler<CalibrationUpdated>
    {
        private readonly ICalibrationsApiClient _calibrationsApiClient;
        private readonly IClock _clock;
        private readonly ICollectionRepository _collectionRepository;
        public CalibrationUpdatedHandler(ICalibrationsApiClient calibrationsApiClient,
            IClock clock,
            ICollectionRepository collectionRepository)
        {
            _calibrationsApiClient = calibrationsApiClient;
            _clock = clock;
            _collectionRepository = collectionRepository;
        }
        public async Task HandleAsync(CalibrationUpdated @event)
        {
            var calibration = await _calibrationsApiClient.GetCalibrationAsync(@event.SurveyEquipmentId);
            if (calibration is null)
            {
                return;
            }

            if (calibration.CalibrationDueDate <= _clock.Current().AddDays(7))
            {
                var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(calibration.SurveyEquipmentId);
                if (collection is not null)
                {
                    await _collectionRepository.DeleteAsync(collection);
                    return;
                }

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