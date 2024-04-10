using System;
using System.Runtime.CompilerServices;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Saga.Messages
{
    internal record StoreCreated(Guid Id) : IEvent;
}
