using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters
{
    public class KitTypeValueConverter
    {
        public static ValueConverter<KitType, string> ValueConverter =
            new ValueConverter<KitType, string>(kt => kt.Value, value => new KitType(value));
    }
}
