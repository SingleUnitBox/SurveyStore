using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class SurveyEquipmentNotFoundInStoreException : SurveyStoreException
    {
        public Guid Id { get; }
        public SurveyEquipmentNotFoundInStoreException(SurveyEquipmentId id)
            : base($"Survey equipment with id '{id.Value}' was not found in store.")
        {
            Id = id;
        }
    }
}