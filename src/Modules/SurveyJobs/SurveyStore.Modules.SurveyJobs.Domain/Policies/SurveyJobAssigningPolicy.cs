using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.Policies
{
    public class SurveyJobAssigningPolicy : ISurveyJobAssigningPolicy
    {
        public bool CanJobBeAssigned(SurveyJob surveyJob, HashSet<Surveyor> surveyors)
        {
            if (surveyJob.Budget.Value > 10_000 && surveyors.Count + surveyJob.Surveyors.Count() < 2)
            {
                return false;
            }

            return true;
        }
    }
}
