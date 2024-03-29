using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Exceptions
{
    public class CollectionNotFoundException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; }
        public CollectionNotFoundException(SurveyEquipmentId surveyEquipmentId)
            : base($"Current collection for survey equipment with id '{surveyEquipmentId.Value}' was not found.")
        {
            SurveyEquipmentId = surveyEquipmentId;
        }
    }
}
