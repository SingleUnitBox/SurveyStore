using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Events
{
    public record SurveyJobCreated(Guid Id) : IEvent;
}
