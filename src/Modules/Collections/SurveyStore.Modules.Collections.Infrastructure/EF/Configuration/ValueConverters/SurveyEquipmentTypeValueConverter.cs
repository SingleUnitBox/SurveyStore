using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters
{
    public static class SurveyEquipmentTypeValueConverter
    {
        public static ValueConverter<SurveyEquipmentType, string> ValueConverter =
            new ValueConverter<SurveyEquipmentType, string>(set => set.Value, value => new(value));
    }
}
