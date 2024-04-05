using System;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Users.Core.Events
{
    public record UserCreated(Guid Id, string Email) : IEvent;
}
