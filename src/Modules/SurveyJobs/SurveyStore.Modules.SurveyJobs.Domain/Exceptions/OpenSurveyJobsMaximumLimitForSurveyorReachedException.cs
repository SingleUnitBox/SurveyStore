using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class OpenSurveyJobsMaximumLimitForSurveyorReachedException : SurveyStoreException
    {
        public Guid SurveyorId { get; }
        public int SurveyJobsCount { get; }
        public OpenSurveyJobsMaximumLimitForSurveyorReachedException(Guid surveyorId, int surveyJobsCount)
            : base($"Surveyor with id '{surveyorId}' has '{surveyJobsCount}' open survey jobs and reached maximum limit.")
        {
            SurveyorId = surveyorId;
            SurveyJobsCount = surveyJobsCount;
        }
    }
}