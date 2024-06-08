using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration.ValueConverters
{
    public static class SurveyTypeConverter
    {
        public static ValueConverter<SurveyType, string> ValueConverter =
            new ValueConverter<SurveyType, string>(s => s.Value, s => SurveyType.Create(s));
    }
}