using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Events
{
    public record EquipmentCollected(SurveyEquipmentId SurveyEquipmentId, SurveyorId SurveyorId) : IDomainEvent;
}
