using System.Collections.Immutable;

namespace SurveyStore.Modules.Collections.Domain.Collections.Consts
{
    public class KitConstants
    {
        public const int TripodRequiredAmount = 3;
        public const int PrismRequiredAmount = 2;

        public static readonly string[] LimitedSurveyEquipmentTypes = new[]
            {
                "total station",
                "gnss"
            };
    }
}
