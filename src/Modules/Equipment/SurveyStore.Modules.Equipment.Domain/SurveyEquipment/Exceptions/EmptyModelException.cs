using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Exceptions
{
    public class EmptyModelException : SurveyStoreException
    {
        public EmptyModelException()
            : base($"Survey equipment model is empty.")
        {
        }
    }
}