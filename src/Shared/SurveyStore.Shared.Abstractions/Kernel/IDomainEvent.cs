using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Shared.Abstractions.Kernel
{
    public interface IDomainEvent : IMessage, IEvent
    {
    }
}
