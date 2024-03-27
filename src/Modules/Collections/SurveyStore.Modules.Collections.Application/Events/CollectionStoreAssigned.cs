using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CollectionStoreAssigned(Guid StoreId) : IEvent;
}
