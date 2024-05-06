using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.Kit.Exceptions
{
    public class KitAlreadyExistsException : SurveyStoreException
    {
        public string KitType { get; }
        public string SerialNumber { get; }
        public KitAlreadyExistsException(string kitType, string serialNumber)
            : base($"{kitType} with serial number '' already exists.")
        {
            KitType = kitType;
            SerialNumber = serialNumber;
        }
    }
}
