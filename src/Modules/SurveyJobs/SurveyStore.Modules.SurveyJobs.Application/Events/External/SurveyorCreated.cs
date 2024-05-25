using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Events.External
{
    public record SurveyorCreated(Guid Id, string Email) : IEvent;
}
