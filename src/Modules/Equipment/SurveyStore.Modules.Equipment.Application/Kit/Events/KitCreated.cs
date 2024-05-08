using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.Events
{
    public record KitCreated(Guid Id) : IEvent;
}
