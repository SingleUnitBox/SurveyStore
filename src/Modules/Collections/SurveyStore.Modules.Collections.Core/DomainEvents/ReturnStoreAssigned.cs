using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.DomainEvents
{
    public record ReturnStoreAssigned(StoreId ReturnStoreId) : IDomainEvent;
}
