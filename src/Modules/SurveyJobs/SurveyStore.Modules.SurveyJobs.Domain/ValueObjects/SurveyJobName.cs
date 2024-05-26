using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class SurveyJobName
    {
        public string Name { get; private set; }

        private SurveyJobName()
        {
            
        }

        public void ChangeSurveyJobName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptySurveyJobNameException(name);
            }

            Name = name;
        }

        public static SurveyJobName Create(string name)
        {
            var surveyJobName = new SurveyJobName();
            surveyJobName.ChangeSurveyJobName(name);

            return surveyJobName;
        }
    }
}