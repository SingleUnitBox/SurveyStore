using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Stores.Core")]
namespace SurveyStore.Services.Stores.Core.Events
{
    internal record StoreCreated(Guid Id, string Name) : IEvent;
}
