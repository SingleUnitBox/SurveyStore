using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public class KitCollectionService : IKitCollectionService
    {
        private readonly KitConstOptions _kitOptions;
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public KitCollectionService(KitConstOptions kitOptions,
            IKitCollectionRepository kitCollectionRepository)
        {
            _kitOptions = kitOptions;
            _kitCollectionRepository = kitCollectionRepository;
        }
        public async Task<IEnumerable<KitCollection>> GatherTraverseSet(IEnumerable<KitCollection> openKitCollections, Surveyor surveyor, Date collectedAt)
        {
            var tripodsToBeCollected = new List<KitCollection>();
            var freeKitCollections = await _kitCollectionRepository
                .BrowseAsPredicateExpression(new IsFreeKitCollection());
                
            var openTripodsAmount = openKitCollections
                .Where(k => k.Kit.Type == KitTypes.Tripod)
                .Count();
            if (openTripodsAmount < _kitOptions.TripodRequiredAmount)
            {
                var freeTripods = freeKitCollections.Where(k => k.Kit.Type == KitTypes.Tripod);
                var availableTripodAmount = freeTripods.Count() + openTripodsAmount;
                if (availableTripodAmount < _kitOptions.TripodRequiredAmount)
                {
                    throw new NotEnoughKitAvailableToFormSetException(
                        KitTypes.Tripod, _kitOptions.TripodRequiredAmount, availableTripodAmount);
                }
                
                foreach (var tripod in freeTripods)
                {
                    if (tripodsToBeCollected.Count() + openTripodsAmount < _kitOptions.TripodRequiredAmount)
                    {
                        tripodsToBeCollected.Add(tripod);
                        _kitCollectionRepository.Detach(tripod);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return tripodsToBeCollected;
            var openTraversePrisms = openKitCollections.Where(k => k.Kit.Type == KitTypes.TraversePrism);
        }
    }
}
