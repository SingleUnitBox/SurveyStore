using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.Commands
{
    public record AddTotalStation(
        string Brand,
        string Model,
        string Description,
        string SerialNumber,
        DateTime PurchasedAt,
        string? StoreName,
        decimal Accuracy,
        int MaxRemoteDistance) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
