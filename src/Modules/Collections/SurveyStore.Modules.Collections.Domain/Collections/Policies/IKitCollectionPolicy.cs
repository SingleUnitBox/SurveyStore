using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Types;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public interface IKitCollectionPolicy
    {
        bool CanBeCollected(IEnumerable<KitCollection> freeKitCollections, string kitType, int requiredAmount);
    }
}
