using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class EmptyModelException : SurveyStoreException
    {
        public EmptyModelException()
            : base($"Model is empty.")
        {
        }
    }
}
