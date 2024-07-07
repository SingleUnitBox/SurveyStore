using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class InvalidSurveyEquipmentTypeException : SurveyStoreException
    {
        public string SurveyEquipmentType { get; }
        public InvalidSurveyEquipmentTypeException(string surveyEquipmentType)
            : base($"Survey equipment type of '{surveyEquipmentType}' is invalid.")
        {
            SurveyEquipmentType = surveyEquipmentType;
        }
    }
}
