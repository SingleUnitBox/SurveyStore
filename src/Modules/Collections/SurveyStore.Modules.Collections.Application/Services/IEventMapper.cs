using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Application.Services
{
    public interface IEventMapper
    {
        IMessage Map(IDomainEvent domainEvent);
        IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> domainEvents);
    }
}
