﻿using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Equipment.Application.Commands
{
    public record AddFieldController(
        string Brand,
        string Model,
        string Description,
        string SerialNumber,
        DateTime PurchasedAt,
        DateTime? CalibrationDate,
        TimeSpan? CalibrationInterval,
        int ScreenSize) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
