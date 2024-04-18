using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.Commands
{
    public record AddGNSS(
        string Brand,
        string Model,
        string Description,
        string SerialNumber,
        DateTime PurchasedAt,
        bool IsActive) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
