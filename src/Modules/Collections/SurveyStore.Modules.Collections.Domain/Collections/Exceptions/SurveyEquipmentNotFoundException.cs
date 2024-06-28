using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
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
