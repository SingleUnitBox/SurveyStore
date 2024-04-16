using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Calibrations.Application.Events
{
    public record CalibrationUpdated(SurveyEquipmentId SurveyEquipmentId) : IEvent;
}
