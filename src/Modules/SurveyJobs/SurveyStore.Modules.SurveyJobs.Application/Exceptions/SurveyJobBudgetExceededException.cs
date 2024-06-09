using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class SurveyJobBudgetExceededException : SurveyStoreException
    {
        public Guid SurveyJobId { get; }
        public SurveyJobBudgetExceededException(Guid surveyJobId)
            : base($"Survey job with '{surveyJobId}' exceeded budget limit to assign to single surveyor.")
        {
            SurveyJobId = surveyJobId;
        }
    }
}
