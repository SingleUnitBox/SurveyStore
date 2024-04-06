using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CreateCollection(SurveyEquipmentId SurveyEquipmentId, StoreId CollectionStoreId) : IEvent;
}
