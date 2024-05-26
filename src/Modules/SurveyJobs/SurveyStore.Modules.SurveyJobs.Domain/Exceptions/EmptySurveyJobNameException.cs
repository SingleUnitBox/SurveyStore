using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class EmptySurveyJobNameException : SurveyStoreException
    {
        public EmptySurveyJobNameException(string name)
            : base($"Survey job name is empty.")
        {
        }
    }
}
