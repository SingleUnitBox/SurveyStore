using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.Kit.Exceptions
{
    public class InvalidKitTypeException : SurveyStoreException
    {
        public string KitType { get; }
        public InvalidKitTypeException(string kitType)
            : base($"Kit type of '{kitType}' is invalid.")
        {

            KitType = kitType;
        }
    }
}
    