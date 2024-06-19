using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public class SurveyEquipmentType
    {
        public string Value { get; }

        public SurveyEquipmentType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptySurveyEquipmentTypeException();
            }

            Value = value;
        }

        public static implicit operator SurveyEquipmentType(string value) => new(value);
        public static implicit operator string(SurveyEquipmentType serialNumber) => serialNumber.Value;
    }
}
