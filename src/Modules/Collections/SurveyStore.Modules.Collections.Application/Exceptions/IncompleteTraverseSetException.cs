using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class IncompleteTraverseSetException : SurveyStoreException
    {
        public IncompleteTraverseSetException()
            : base($"Traverse set is incomplete to be returned.")
        {
        }
    }
}
