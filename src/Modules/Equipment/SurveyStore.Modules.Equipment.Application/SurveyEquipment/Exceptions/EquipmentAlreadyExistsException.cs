using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions
{
    public class EquipmentAlreadyExistsException : SurveyStoreException
    {
        public string SerialNumber { get; }
        public EquipmentAlreadyExistsException(string serialNumber)
            : base($"Survey equipment with serial number '{serialNumber}' already exists.")
        {
            SerialNumber = serialNumber;
        }
    }
}
