using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SurveyStore.Modules.Collections.Domain.Collections.ValueObjects
{
    public class KitType
    {
        public string Value { get; private set; }

        public KitType(string value)
        {
            if (!KitTypes.GetKitTypes().Contains(value))
            {
                throw new InvalidKitTypeException(value);
            }

            Value = value;
        }

        public static implicit operator string(KitType kitType) => kitType.Value;
        public static implicit operator KitType(string kitType) => new(kitType);
    }
}
