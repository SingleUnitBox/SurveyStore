using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class AvailableCollectionAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public AvailableCollectionAlreadyExistsException(AggregateId id)
            : base($"Available collection already exists for survey equipment with id '{id.Value}'.")
        {
            Id = id;
        }
    }
}
