using System;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events
{
    public record CreateCollection(SurveyEquipment SurveyEquipment, Guid StoreId) : IEvent;
}
