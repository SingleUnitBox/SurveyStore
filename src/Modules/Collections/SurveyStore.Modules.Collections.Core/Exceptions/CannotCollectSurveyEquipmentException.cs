using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Core.Exceptions
{
    public class CannotCollectSurveyEquipmentException : SurveyStoreException
    {
        public string Type { get; }
        public CannotCollectSurveyEquipmentException(string type)
            : base($"Cannot collect survey equipment of type '{type}'.")
        {
            Type = type;
        }
    }
}
