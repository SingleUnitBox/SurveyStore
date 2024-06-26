using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class InvalidKitTypeException : SurveyStoreException
    {
        public string KitType { get; }
        public InvalidKitTypeException(string kitType)
            : base($"Kit type '{kitType}' is invalid.")
        {
            kitType = KitType;
        }
    }
}
