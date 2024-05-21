using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class IncompleteTraverseSetException : SurveyStoreException
    {
        public string KitType { get; }
        public int RequiredAmount { get; }
        public int ActualAmount { get; }

        public IncompleteTraverseSetException(string kitType, int requiredAmount, int actualAmount)
            : base($"Traverse set is incomplete to be returned. " +
                  $"Required amount of '{kitType}' is '{requiredAmount}' but only '{actualAmount}' have been found.")
        {
            RequiredAmount = requiredAmount;
            ActualAmount = actualAmount;
            KitType = kitType;
        }
    }
}
