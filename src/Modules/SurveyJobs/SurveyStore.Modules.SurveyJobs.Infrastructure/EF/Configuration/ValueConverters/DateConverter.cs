using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using System;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration.ValueConverters
{
    public static class DateConverter
    {
        public static ValueConverter<Date, DateTime> ValueConverter =
            new ValueConverter<Date, DateTime>(d => d.Value, dt => Date.Create(dt));
    }
}