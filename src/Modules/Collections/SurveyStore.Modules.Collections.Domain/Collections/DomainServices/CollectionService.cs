using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    internal class CollectionService : ICollectionService
    {
        private readonly IKitCollectionPolicy _kitCollectionPolicy;

        public CollectionService(IKitCollectionPolicy kitCollectionPolicy)
        {
            _kitCollectionPolicy = kitCollectionPolicy;
        }

        public void CanBeCollected(IEnumerable<Collection> openCollections, Surveyor surveyor, Collection toBeCollected, DateTime now)
        {
            var surveyEquipmentTypes = openCollections.Select(c => c.SurveyEquipment.Type);
            foreach (var surveyEquipmentType in surveyEquipmentTypes)
            {
                if (KitConstants.LimitedSurveyEquipmentTypes.Contains(surveyEquipmentType)
                    && toBeCollected.SurveyEquipment.Type == surveyEquipmentType)
                {
                    throw new CannotCollectSurveyEquipmentException(surveyEquipmentType);
                }
            }

            //toBeCollected.Collect(surveyor, now);
        }

        public IEnumerable<Kit> CollectTraverseSet(IEnumerable<KitCollection> freeKitCollections,
            Surveyor surveyor, Collection toBeCollected, DateTime now)
        {
            var (isEnough, actualAmount) = _kitCollectionPolicy
                .IsEnoughKit(freeKitCollections, KitTypes.Tripod.ToString(), KitConstants.TripodRequiredAmount);
            if (!isEnough)
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.Tripod, KitConstants.TripodRequiredAmount, actualAmount);
            }

            (isEnough, actualAmount) = _kitCollectionPolicy
                .IsEnoughKit(freeKitCollections, KitTypes.TraversePrism.ToString(), KitConstants.PrismRequiredAmount);
            if (!isEnough)
            {
                throw new NotEnoughKitAvailableToFormSetException(KitTypes.TraversePrism, KitConstants.PrismRequiredAmount, actualAmount);
            }

            var collectionStoreId = toBeCollected.CollectionStoreId;
            var tripods = _kitCollectionPolicy.KitToBeCollected(freeKitCollections, KitTypes.Tripod.ToString(),
                collectionStoreId, KitConstants.TripodRequiredAmount);
            foreach (var tripod in tripods)
            {
                tripod.Collect(surveyor, now);
            }

            var prisms = _kitCollectionPolicy.KitToBeCollected(freeKitCollections, KitTypes.TraversePrism.ToString(),
                collectionStoreId, KitConstants.PrismRequiredAmount);
            foreach (var prism in prisms)
            {
                prism.Collect(surveyor, now);
            }

            var kit = new List<Kit>();
            kit.AddRange(tripods.Select(t => t.Kit));
            kit.AddRange(prisms.Select(p => p.Kit));
            
            toBeCollected.Collect(surveyor, now);

            return kit;
        }
    }
}
