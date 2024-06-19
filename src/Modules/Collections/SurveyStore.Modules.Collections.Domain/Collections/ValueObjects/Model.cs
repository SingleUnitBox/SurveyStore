using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using System.Runtime.CompilerServices;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public class Model
    {
        public string Value { get; }

        public Model(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyModelException();
            }

            Value = value;
        }

        public static implicit operator Model(string value) => new(value);
        public static implicit operator string(Model serialNumber) => serialNumber.Value;
    }
}