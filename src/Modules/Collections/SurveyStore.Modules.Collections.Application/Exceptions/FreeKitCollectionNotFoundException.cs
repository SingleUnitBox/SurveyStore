using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class FreeKitCollectionNotFoundException : SurveyStoreException
    {
        public Guid KitId { get; }
        public FreeKitCollectionNotFoundException(Guid kitId)
            : base($"Free collection for kit with id '{kitId}' was not found.")
        {
            KitId = kitId;
        }
    }
}
