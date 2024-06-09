using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Policies
{
    public class SurveyJobAssigningPolicy : ISurveyJobAssigningPolicy
    {
        public bool CanJobBeAssign(SurveyJob surveyJob, HashSet<Surveyor> surveyors)
        {
            if (surveyJob.Budget.Value > 10_000 && surveyors.Count < 2)
            {
                return false;
            }

            return true;
        }
    }
}
