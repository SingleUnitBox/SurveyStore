using SurveyStore.Modules.Collections.Application.Clients.Calibrations.DTO;
using SurveyStore.Shared.Abstractions.Time;

namespace SurveyStore.Modules.Collections.Application.Policies
{
    internal sealed class FreeCollectionRemovalPolicy : IFreeCollectionRemovalPolicy
    {
        private readonly IClock _clock;

        public FreeCollectionRemovalPolicy(IClock clock)
        {
            _clock = clock;
        }

        public bool CanBeDeleted(CalibrationDto calibration)
        {
            if (calibration.CalibrationDueDate <= _clock.Current().AddDays(7))
            {
                return true;
            }

            return false;
        }
    }
}
