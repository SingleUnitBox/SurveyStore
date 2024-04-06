using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class OpenCollectionNotFoundException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; }
        public OpenCollectionNotFoundException(SurveyEquipmentId surveyEquipmentId)
            : base($"Open collection for survey equipment with id '{surveyEquipmentId.Value}' was not found.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
