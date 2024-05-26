using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class SurveyJobNotFoundException : SurveyStoreException
    {
        public Guid SurveyJobId { get; }
        public SurveyJobNotFoundException(Guid surveyJobId)
            : base($"Survey job with id '{surveyJobId}' was not found.")
        {
            SurveyJobId = surveyJobId;
        }
    }
}