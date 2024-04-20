using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Calibrations.Application.Commands
{
    public record Calibrate(string SerialNumber, DateTime CalibrationDueDate, string CertificateNumber) : ICommand;
}
