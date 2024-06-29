using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class KitNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public KitNotFoundException(Guid id)
            : base($"Kit with id '{id}' was not found.")
        {
            Id = id;
        }
    }
}
