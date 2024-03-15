using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Commands;

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
        string StoreName,
        decimal Accuracy,
        int MaxRemoteDistance) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
