using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents
{
    public record KitReadyForCollection(KitId KitId, SurveyorId SurveyorId, StoreId CollectionStoreId) : IDomainEvent;
}
