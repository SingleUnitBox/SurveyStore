using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Commands
{
    public record AddFieldController(
        string Brand,
        string Model,
        string Description,
        string SerialNumber,
        DateTime PurchasedAt,
        int ScreenSize) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
