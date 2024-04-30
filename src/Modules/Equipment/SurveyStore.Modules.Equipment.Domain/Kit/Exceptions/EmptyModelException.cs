using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Exceptions
{
    public class EmptyModelException : SurveyStoreException
    {
        public string KitType { get; }
        public EmptyModelException(string kitType)
            : base($"{kitType} model is empty.")
        {
            KitType = kitType;
        }
    }
}