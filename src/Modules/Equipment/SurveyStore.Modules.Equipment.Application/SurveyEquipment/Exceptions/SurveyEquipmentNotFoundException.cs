using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions
{
    public class SurveyEquipmentNotFoundException : SurveyStoreException
    {
        public string SerialNumber { get; }
        public Guid Id { get; }
        public SurveyEquipmentNotFoundException(string serialNumber)
            : base($"Survey equipment with serial number '{serialNumber}' was not found.")
        {
            SerialNumber = serialNumber;
        }

        public SurveyEquipmentNotFoundException(Guid id)
            : base($"Survey equipment with id '{id}' was not found.")
        {
            Id = id;
        }
    }
}
