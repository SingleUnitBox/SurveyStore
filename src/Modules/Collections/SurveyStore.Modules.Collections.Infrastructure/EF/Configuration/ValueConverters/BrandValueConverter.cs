using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters
{
    public class BrandValueConverter
    {
        public static ValueConverter<Brand, string> ValueConverter =
            new ValueConverter<Brand, string>(b => b.Value, value => new Brand(value));
    }
}
