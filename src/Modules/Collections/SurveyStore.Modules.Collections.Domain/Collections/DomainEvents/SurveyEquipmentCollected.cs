using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents
{
    public record SurveyEquipmentCollected(SurveyEquipmentId SurveyEquipmentId, StoreId CollectionStoreId) : IDomainEvent;
}
