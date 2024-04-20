using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class FreeCollectionNotFoundException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; }
        public FreeCollectionNotFoundException(SurveyEquipmentId surveyEquipmentId)
            : base($"Free collection for survey equipment with id '{surveyEquipmentId.Value}' was not found.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
