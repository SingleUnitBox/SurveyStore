using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public class Brand
    {
        public string Value { get; }

        public Brand(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyBrandException();
            }

            Value = value;
        }

        public static implicit operator Brand(string value) => new(value);
        public static implicit operator string(Brand serialNumber) => serialNumber.Value;
    }
}