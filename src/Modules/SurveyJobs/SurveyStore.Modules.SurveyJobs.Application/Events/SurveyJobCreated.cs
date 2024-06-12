using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.SurveyJobs.Application.Events
{
    public record SurveyJobCreated(AggregateId Id) : IEvent;
}
