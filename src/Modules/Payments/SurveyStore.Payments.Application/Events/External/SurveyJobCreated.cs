using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Payments.Application.Events.External
{
    public record SurveyJobCreated(Guid Id) : IEvent;
}
