using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class NotEnoughKitAvailableToFormSetException : SurveyStoreException
    {
        public string KitType { get; }
        public int RequiredAmount { get; }
        public int ActualAmount { get; }
        public NotEnoughKitAvailableToFormSetException(string kitType, int requiredAmount, int actualAmount)
            : base($"There is not enough kit of type '{kitType}' to form set of '{requiredAmount}'." +
                  $" Only '{actualAmount}' available.")
        {
            KitType = kitType;
            RequiredAmount = requiredAmount;
            ActualAmount = actualAmount;
        }
    }
}
