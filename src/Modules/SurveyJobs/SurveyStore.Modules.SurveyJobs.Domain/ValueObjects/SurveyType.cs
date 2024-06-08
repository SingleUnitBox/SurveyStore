using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class SurveyType
    {
        public string Value { get; private set; }

        private SurveyType()
        {
            
        }

        public void ChangeSurveyType(string surveyType)
        {
            var surveyJobTypes = SurveyJobTypes.GetSurveyTypes();
            if (!surveyJobTypes.Contains(surveyType.ToLowerInvariant()))
            {
                throw new InvalidSurveyJobTypeException(surveyType);
            }

            Value = surveyType;
        }

        public static SurveyType Create(string surveyTypeString)
        {
            var surveyType = new SurveyType();
            surveyType.ChangeSurveyType(surveyTypeString);

            return surveyType;
        }

        public static implicit operator SurveyType(string surveyType) => Create(surveyType);
    }
}
