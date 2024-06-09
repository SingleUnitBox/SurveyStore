using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Policies
{
    public interface ISurveyJobAssigningPolicy
    {
        bool CanJobBeAssigned(SurveyJob surveyJob, HashSet<Surveyor> surveyors);
    }
}
