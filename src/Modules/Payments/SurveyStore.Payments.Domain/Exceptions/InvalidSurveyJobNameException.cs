using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Payments.Domain.Exceptions
{
    public class InvalidSurveyJobNameException : SurveyStoreException
    {
        public string Name { get; }
        public InvalidSurveyJobNameException(string name)
            : base($"Survey job name '{name}' is invalid.")
        {
            Name = name;
        }
    }
}