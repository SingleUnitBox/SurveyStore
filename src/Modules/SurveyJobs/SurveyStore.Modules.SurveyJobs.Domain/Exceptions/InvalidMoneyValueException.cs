using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidMoneyValueException : SurveyStoreException
    {
        public int Value { get; }
        public InvalidMoneyValueException(int value)
            : base($"Money value '{value}' is invalid.")
        {
            Value = value;
        }
    }
}
