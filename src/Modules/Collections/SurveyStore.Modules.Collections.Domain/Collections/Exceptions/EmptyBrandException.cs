using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class EmptyBrandException : SurveyStoreException
    {
        public EmptyBrandException()
            : base($"Brand is empty.")
        {
        }
    }
}
