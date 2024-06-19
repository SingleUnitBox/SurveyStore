using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class EmptySurveyEquipmentTypeException : SurveyStoreException
    {
        public EmptySurveyEquipmentTypeException()
            : base($"Type is empty.")
        {
        }
    }
}
