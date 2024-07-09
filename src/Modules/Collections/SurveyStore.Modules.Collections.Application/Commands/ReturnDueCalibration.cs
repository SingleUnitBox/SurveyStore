using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record ReturnDueCalibration(Guid SurveyEquipmentId, string CalibrationStatus) : ICommand;
}
