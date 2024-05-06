using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions
{
    public class SurveyEquipmentTypeNotFoundException : SurveyStoreException
    {
        public string Type { get; }
        public SurveyEquipmentTypeNotFoundException(string type)
            : base($"Survey equipment type of '{type}' was not found.")
        {
            Type = type;
        }
    }
}
