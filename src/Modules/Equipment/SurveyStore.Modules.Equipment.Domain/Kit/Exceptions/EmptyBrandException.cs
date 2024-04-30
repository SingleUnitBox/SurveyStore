using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Exceptions
{
    public class EmptyBrandException : SurveyStoreException
    {
        public string KitType { get; }
        public EmptyBrandException(string kitType)
            : base($"{kitType} brand is empty.")
        {
            KitType = kitType;
        }
    }
}
