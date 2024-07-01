using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CollectionCreated(Guid Id, Guid SurveyEquipmentId) : IEvent;
}
