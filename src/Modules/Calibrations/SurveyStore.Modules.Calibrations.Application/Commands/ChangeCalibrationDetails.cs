using SurveyStore.Modules.Calibrations.Domain.Types;
using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Commands
{
    internal record ChangeCalibrationDetails(string SerialNumber, DateTime? CalibrationDueDate,
        TimeSpan? CalibrationInterval, string? CertificateNumber, CalibrationStatus? CalibrationStatus) : ICommand;
}
