using SurveyStore.Modules.Collections.Application.Clients.Calibrations.DTO;

namespace SurveyStore.Modules.Collections.Application.Policies
{
    public interface ICollectionRemovalPolicy
    {
        bool CanBeDeleted(CalibrationDto calibration);
    }
}
