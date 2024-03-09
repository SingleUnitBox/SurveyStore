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
        DateTime? CalibrationDate,
        TimeSpan? CalibrationInterval,
        decimal? Accuracy,
        int MaxRemoteDistance) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
