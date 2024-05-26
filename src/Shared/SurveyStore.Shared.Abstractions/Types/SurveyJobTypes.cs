using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Shared.Abstractions.Types
{
    public class SurveyJobTypes
    {
        public const string Topo = nameof(Topo);
        public const string Utility = nameof(Utility);
        public const string SettingOut = nameof(SettingOut);
        public const string Monitoring = nameof(Monitoring);
        public const string AsBuilt = nameof(AsBuilt);
        public const string Traverse = nameof(Traverse);
        public const string Levelling = nameof(Levelling);

        public static IEnumerable<string> GetSurveyTypes()
        {
            var surveyTypes = typeof(SurveyJobTypes)
                .GetFields(BindingFlags.Public | BindingFlags.Static |BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(field => field.GetValue(null).ToString().ToLowerInvariant())
                .ToList();

            return surveyTypes;
        }
    }
}
