using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Surveyors.Core.Exceptions
{
    public class SurveyorAlreadyExistException : SurveyStoreException
    {
        public string Email { get; }
        public SurveyorAlreadyExistException(string email)
            : base($"Surveyor with email '{email}' already exists.")
        {
            Email = email;
        }
    }
}
