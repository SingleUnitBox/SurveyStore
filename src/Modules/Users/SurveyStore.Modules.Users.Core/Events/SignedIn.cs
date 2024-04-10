using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Users.Core.Events
{
    public record SignedIn(Guid Id, string Email) : IEvent;
}
