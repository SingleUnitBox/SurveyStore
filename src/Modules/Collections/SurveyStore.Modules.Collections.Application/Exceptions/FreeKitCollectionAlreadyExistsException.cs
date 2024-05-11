using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class FreeKitCollectionAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public FreeKitCollectionAlreadyExistsException(KitId id)
            : base($"Free kit collection already exists for survey equipment with id '{id}'.")
        {
            Id = id;
        }
    }
}
