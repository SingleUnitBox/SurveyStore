using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Shared.Abstractions.Types
{
    public class KitTypes
    {
        public const string Tripod = nameof(Tripod);
        public const string TraversePrism = nameof(TraversePrism);
        public const string DetailPole = nameof(DetailPole);
        public const string GNSSPole = nameof(GNSSPole);

        public static IEnumerable<string> GetKitTypes()
            => typeof(KitTypes).GetFields().Select(k => k.Name);
    }
}