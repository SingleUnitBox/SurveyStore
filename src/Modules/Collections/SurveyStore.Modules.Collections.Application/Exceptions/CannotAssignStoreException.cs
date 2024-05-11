using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class CannotAssignStoreException : SurveyStoreException
    {
        public Guid SurveyEquipmentId { get; }
        public Guid KitId { get; }

        public CannotAssignStoreException(Guid surveyEquipmentId)
            : base($"Cannot assign store to survey equipment with id '{surveyEquipmentId}' as it is marked as collected.")

        {
            SurveyEquipmentId = surveyEquipmentId;
        }

        public CannotAssignStoreException(KitId kitId)
            : base($"Cannot assign store to kit with id '{kitId}' as it is marked as collected.")

        {
            KitId = kitId;
        }
    }
}
