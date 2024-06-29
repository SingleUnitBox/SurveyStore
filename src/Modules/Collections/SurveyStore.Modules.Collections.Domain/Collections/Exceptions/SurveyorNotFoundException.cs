using System;
using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class SurveyorNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public SurveyorNotFoundException(SurveyorId surveyorId)
            : base($"Surveyor with id '{surveyorId.Value}' was not found.")
        {
            Id = surveyorId.Value;
        }
    }
}
