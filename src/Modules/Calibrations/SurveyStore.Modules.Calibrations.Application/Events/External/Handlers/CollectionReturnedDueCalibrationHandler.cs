using SurveyStore.Modules.Calibrations.Application.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Application.Events.External.Handlers
{
    internal sealed class CollectionReturnedDueCalibrationHandler : IEventHandler<CollectionReturnedDueCalibration>
    {
        private readonly ICalibrationsRepository _calibrationsRepository;
        private readonly IClock _clock;
        private readonly IMessageBroker _messageBroker;

        public CollectionReturnedDueCalibrationHandler(ICalibrationsRepository calibrationsRepository,
            IClock clock,
            IMessageBroker messageBroker)
        {
            _calibrationsRepository = calibrationsRepository;
            _clock = clock;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(CollectionReturnedDueCalibration @event)
        {
            var calibration = (await _calibrationsRepository
                .BrowseForSurveyEquipmentAsync(@event.SurveyEquipmentId))
                .SingleOrDefault();
            if (calibration is null)
            {
                throw new CalibrationNotFoundException(@event.SurveyEquipmentId);
            }

            calibration.Renew(_clock.Current());
            await _calibrationsRepository.UpdateAsync(calibration);
            await _messageBroker.PublishAsync(new CalibrationRenewed(@event.SurveyEquipmentId, calibration.CalibrationStatus));
        }
    }
}
