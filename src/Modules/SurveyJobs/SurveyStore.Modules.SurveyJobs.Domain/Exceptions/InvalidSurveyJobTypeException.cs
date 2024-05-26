using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidSurveyJobTypeException : SurveyStoreException
    {
        public string SurveyJobType { get; }
        public InvalidSurveyJobTypeException(string surveyJobType)
            : base($"Survey job type '{surveyJobType}' is invalid.")
        {
            SurveyJobType = surveyJobType;
        }
    }
}
