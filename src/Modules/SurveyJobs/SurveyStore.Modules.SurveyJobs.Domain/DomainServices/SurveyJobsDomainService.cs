using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.DomainServices
{
    public class SurveyJobsDomainService : ISurveyJobsDomainService
    {
        public void AssignSurveyor(SurveyJob surveyJob, IEnumerable<SurveyJob> openSurveyJobs, Surveyor surveyor)
        {
            if (openSurveyJobs.Count() > 1)
            {
                throw new OpenSurveyJobsMaximumLimitForSurveyorReachedException(surveyor.Id, openSurveyJobs.Count());
            }

            surveyJob.AddSurveyor(surveyor);
        }
    }
}