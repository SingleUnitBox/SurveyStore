using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.Entities
{
    public class Calibration : AggregateRoot
    {
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public DateTime CalibrationDueDate { get; private set; }

    }
}
