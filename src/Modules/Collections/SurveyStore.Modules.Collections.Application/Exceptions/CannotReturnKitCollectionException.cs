using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class CannotReturnKitCollectionException : SurveyStoreException
    {
        public Guid KitId { get; }
        public CannotReturnKitCollectionException(Guid kitId)
            : base($"Cannot return kit collection with id '{kitId}'.")
        {
            KitId = kitId;
        }
    }
}
