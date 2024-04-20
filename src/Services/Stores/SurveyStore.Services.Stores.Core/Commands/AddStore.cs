using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Services.Stores.Core.Commands
{
    public record AddStore(string Name, string Location, DateTime OpeningTime, DateTime ClosingTime) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
