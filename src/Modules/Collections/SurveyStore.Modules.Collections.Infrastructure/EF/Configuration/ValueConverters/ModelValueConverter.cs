

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters
{
    public static class ModelValueConverter
    {
        public static ValueConverter<Model, string> ValueConverter =
            new ValueConverter<Model, string>(m => m.Value, value => new(value));
    }
}
