using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class SurveyEquipmentToBeCalibratedException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; }
        public SurveyEquipmentToBeCalibratedException(Guid surveyEquipmentId)
            : base($"Cannot assign store. Survey equipment with id '{surveyEquipmentId}' has to be calibrated.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
