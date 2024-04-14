using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class CannotAssignStoreException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; set; }
        public CannotAssignStoreException(Guid surveyEquipmentId)
            : base($"Cannot assign store to survey equipment with id '{surveyEquipmentId}' as it is marked as collected.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
