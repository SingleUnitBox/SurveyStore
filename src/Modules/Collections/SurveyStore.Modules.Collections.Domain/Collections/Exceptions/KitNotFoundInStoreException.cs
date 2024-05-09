using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class KitNotFoundInStoreException : SurveyStoreException
    {
        public Guid Id { get; }
        public KitNotFoundInStoreException(AggregateId id)
            : base($"Kit with id '{id.Value}' was not found in store.")
        {
            Id = id;
        }
    }
}
