using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidFirstNameException : SurveyStoreException
    {
        public string FirstName { get; }
        public InvalidFirstNameException(string firstName)
            : base($"First name '{firstName}' is invalid.")
        {
            FirstName = firstName;
        }
    }
}
