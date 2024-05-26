using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Shared.Abstractions.Types
{
    public class DocumentTypes
    {
        public static readonly DocumentTypes Photo = new DocumentTypes(nameof(Photo));
        public static readonly DocumentTypes DynamicRiskAssessment = new DocumentTypes(nameof(DynamicRiskAssessment));
        public static readonly DocumentTypes Stats = new DocumentTypes(nameof(Stats));

        public string Name { get; private set; }

        public DocumentTypes(string name)
        {
            Name = name;
        }

        public static IEnumerable<string> GetDocumentTypes()
        {
            var documentTypes = typeof(DocumentTypes)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsInitOnly && field.FieldType == typeof(DocumentTypes))
                //.Select(field => field.GetValue(null).ToString())
                .Select(field => field.Name.ToLowerInvariant())
                .ToList();

            return documentTypes;
        }
    }
}