using SurveyStore.Modules.Payments.Domain.Exceptions;

namespace SurveyStore.Modules.Payments.Domain.ValueObjects
{
    public class SurveyJobName
    {
        public string Value { get; private set; }

        public SurveyJobName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidSurveyJobNameException(name);
            }

            Value = name;
        }
    }
}
