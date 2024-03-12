using System;
using System.Runtime.CompilerServices;
using SurveyStore.Shared.Abstractions.Events;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Equipment.Application")]
[assembly: InternalsVisibleTo("SurveyStore.Modules.Stores.Core")]
namespace SurveyStore.Modules.Equipment.Application.Events.External
{
    internal record StoreCreated(Guid Id, string Name) : IEvent;
}
