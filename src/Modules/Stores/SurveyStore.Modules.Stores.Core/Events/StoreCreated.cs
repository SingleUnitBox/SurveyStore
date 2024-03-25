using System;
using System.Runtime.CompilerServices;
using SurveyStore.Shared.Abstractions.Events;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Stores.Core")]
namespace SurveyStore.Modules.Stores.Core.Events
{
    internal record StoreCreated(Guid Id, string Name) : IEvent;
}
