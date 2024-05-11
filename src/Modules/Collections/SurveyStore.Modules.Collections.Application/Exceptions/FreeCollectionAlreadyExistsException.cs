using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class FreeCollectionAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public FreeCollectionAlreadyExistsException(SurveyEquipmentId id)
            : base($"Free collection already exists for survey equipment with id '{id}'.")
        {
            Id = id;
        }
    }
}
