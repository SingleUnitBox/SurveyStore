using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Types;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public class KitCollectionPolicy : IKitCollectionPolicy
    {
        public bool CanBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount)
        {
            var freeKitTypes = freeKitCollections.Select(k => k.Kit.Type);
            if (freeKitTypes.Count(t => t == kitType) < requiredAmount)
            {
                return false;
            }

            return true;
        }
    }
}
