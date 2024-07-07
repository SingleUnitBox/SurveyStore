using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Shared.Abstractions.Types
{
    public class CalibrationStatuses
    {
        public const string CalibrationDue = nameof(CalibrationDue);
        public const string UnderCalibration = nameof(UnderCalibration);
        public const string Calibrated = nameof(Calibrated);
        public const string Uncalibrated = nameof(Uncalibrated);
        public const string Unknown = nameof(Unknown);

        public static IEnumerable<string> GetCalibrationStatusTypes()
    => typeof(CalibrationStatuses)
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(field => field.IsLiteral && !field.IsInitOnly)
        .Select(field => field.GetValue(null).ToString().ToLowerInvariant())
        .ToList();
    }
}
