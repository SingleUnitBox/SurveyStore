using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters
{
    public class SerialNumberConverter
    {
        public static ValueConverter<SerialNumber, string> ValueConverter =
            new ValueConverter<SerialNumber, string>(sn => sn.Value, value => new SerialNumber(value));
    }
}
