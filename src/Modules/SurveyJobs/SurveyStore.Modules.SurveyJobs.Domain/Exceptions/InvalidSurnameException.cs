using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidSurnameException : SurveyStoreException
    {
        public string Surname { get; }
        public InvalidSurnameException(string surname)
            : base($"First name '{surname}' is invalid.")
        {
            Surname = surname;
        }
    }
}