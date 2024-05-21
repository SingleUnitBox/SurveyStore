using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Types;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public class KitCollectionService : IKitCollectionService
    {
        public (bool, IEnumerable<KitCollection>) IsTraverseSetFullForReturn(IEnumerable<KitCollection> openKitCollections)
        {
            var tripods = FilterAndValidateKit(openKitCollections, KitTypes.Tripod, KitConstants.TripodRequiredAmount);
            if (!tripods.areEnough)
            {
                return (false, tripods.filteredKit);
            }

            var prisms = FilterAndValidateKit(openKitCollections,
                KitTypes.TraversePrism, KitConstants.PrismRequiredAmount);
            if (!prisms.areEnough)
            {
                return (false, prisms.filteredKit);
            }

            var traverseSet = new List<KitCollection>();
            traverseSet.AddRange(tripods.filteredKit);
            traverseSet.AddRange(prisms.filteredKit);

            return (true, traverseSet);
        }

        private (bool areEnough, List<KitCollection> filteredKit) FilterAndValidateKit(IEnumerable<KitCollection> kitCollection,
            string kitType, int requiredAmount)
        {
            var filteredKit = kitCollection
                .Where(k => k.Kit.Type == kitType)
                .ToList();
            if (filteredKit.Count < requiredAmount)
            {
                return (false, filteredKit);
            }

            return (true, filteredKit);
        }
    }
}
