using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Shared.Abstractions.Types
{
    public class SurveyEquipmentTypes
    {
        public const string TotalStation = nameof(TotalStation);
        public const string GNSS = nameof(GNSS);
        public const string FieldController = nameof(FieldController);
        public const string GroundPenetratingRadar = nameof(GroundPenetratingRadar);
        public const string CAT = nameof(CAT);

        public static IEnumerable<string> GetSurveyEquipmentTypes()
        {
            var surveyEquipmentTypes = typeof(SurveyEquipmentTypes)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(field => field.GetValue(null).ToString().ToLowerInvariant())
                .ToList();

            return surveyEquipmentTypes;
        }
    }
}