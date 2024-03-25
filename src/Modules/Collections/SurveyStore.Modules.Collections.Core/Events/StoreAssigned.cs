using System;
using SurveyStore.Shared.Abstractions.Kernel;

namespace SurveyStore.Modules.Collections.Core.Events
{
    public record StoreAssigned(Guid StoreId, string Name) : IDomainEvent;

}
