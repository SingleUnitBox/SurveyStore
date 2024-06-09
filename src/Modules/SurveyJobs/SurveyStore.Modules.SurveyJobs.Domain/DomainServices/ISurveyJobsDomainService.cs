using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.DomainServices
{
    public interface ISurveyJobsDomainService
    {
        void AssignSurveyor(SurveyJob surveyJob, IEnumerable<SurveyJob> openSurveyJobs, Surveyor surveyor);
    }
}
