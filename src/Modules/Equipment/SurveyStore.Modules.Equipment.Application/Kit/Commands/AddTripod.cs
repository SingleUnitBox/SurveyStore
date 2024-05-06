using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.Commands
{
    public record AddTripod(string brand, string model, string serialNumber, DateTime purchasedAt) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
