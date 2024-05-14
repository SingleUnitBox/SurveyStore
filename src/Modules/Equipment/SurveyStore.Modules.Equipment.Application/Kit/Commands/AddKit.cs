using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.Commands
{
    public record AddKit(string Brand, string Model, string SerialNumber, string KitType, DateTime PurchasedAt) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
