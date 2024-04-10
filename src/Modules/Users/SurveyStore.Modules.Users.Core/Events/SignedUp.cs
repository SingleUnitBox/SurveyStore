using SurveyStore.Shared.Abstractions.Events;
using System;

namespace SurveyStore.Modules.Users.Core.Events
{
    public record SignedUp(Guid Id, string Email) : IEvent;
}
