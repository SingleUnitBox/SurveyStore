using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class NotEnoughKitAvailableToFormSetException : SurveyStoreException
    {
        public string KitType { get; }
        public NotEnoughKitAvailableToFormSetException(string kitType)
            : base($"There is not enough kit of type '{kitType}' to form set.")
        {
            KitType = kitType;
        }
    }
}
