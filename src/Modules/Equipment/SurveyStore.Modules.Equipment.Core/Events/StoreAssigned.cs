using System;
using SurveyStore.Shared.Abstractions.Kernel;

namespace SurveyStore.Modules.Equipment.Core.Events
{
    public record StoreAssigned(Guid StoreId, string Name) : IDomainEvent;

}
