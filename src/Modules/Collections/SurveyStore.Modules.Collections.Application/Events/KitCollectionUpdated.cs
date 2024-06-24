using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record KitCollectionUpdated(KitId KitId, StoreId CollectionStoreId) : IEvent;
}
