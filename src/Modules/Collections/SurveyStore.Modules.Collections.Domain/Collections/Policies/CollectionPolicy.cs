using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public class CollectionPolicy : ICollectionPolicy
    {
        public bool IsCalibrationDue(Collection collection, string CalibrationStatus)
        {
            if (CalibrationStatuses.CalibrationDue == CalibrationStatus
                || CalibrationStatuses.Uncalibrated == CalibrationStatus)
            {
                return true;
            }

            return false;
        }
    }
}