using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration.ValueConverters
{
    public static class SurveyJobNameConverter
    {
        public static ValueConverter<SurveyJobName, string> ValueConverter = 
            new ValueConverter<SurveyJobName, string>(n => n.Name, n => SurveyJobName.Create(n));
    }
}
