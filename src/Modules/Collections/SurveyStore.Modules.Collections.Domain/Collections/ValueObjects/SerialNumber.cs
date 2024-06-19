using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using System.Runtime.CompilerServices;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public class SerialNumber
    {
        public string Value { get; }

        public SerialNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptySerialNumberException();
            }

            Value = value;
        }

        public static implicit operator SerialNumber(string value) => new(value);
        public static implicit operator string(SerialNumber serialNumber) => serialNumber.Value;
    }
}