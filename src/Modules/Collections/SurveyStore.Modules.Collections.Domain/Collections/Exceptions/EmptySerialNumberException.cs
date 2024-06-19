using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class EmptySerialNumberException : SurveyStoreException
    {
        public EmptySerialNumberException()
            : base($"Serial number is empty.")
        {
        }
    }
}
