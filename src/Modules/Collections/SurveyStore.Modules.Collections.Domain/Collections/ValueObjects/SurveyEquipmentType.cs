using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public record SurveyEquipmentType //: IEquatable<SurveyEquipmentType>
    {
        public string Value { get; }

        public SurveyEquipmentType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptySurveyEquipmentTypeException();
            }

            if (!SurveyEquipmentTypes.GetSurveyEquipmentTypes().Contains(value))
            {
                throw new InvalidSurveyEquipmentTypeException(value);
            }

            Value = value;
        }

        public static implicit operator SurveyEquipmentType(string value) => new(value);
        public static implicit operator string(SurveyEquipmentType serialNumber) => serialNumber.Value;

        //public bool Equals(SurveyEquipmentType other)
        //{
        //    return Value == other.Value;
        //}
    }
}
