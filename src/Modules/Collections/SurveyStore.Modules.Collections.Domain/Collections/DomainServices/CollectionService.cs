using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    internal class CollectionService : ICollectionService
    {
        private readonly KitConstOptions _kitConstOptions;

        public CollectionService(KitConstOptions kitConstOptions)
        {
            _kitConstOptions = kitConstOptions;
        }

        public void Collect(IEnumerable<Collection> openCollections, Collection toBeCollected, Surveyor surveyor,
            Date collectedAt)
        {
            var openSurveyEquipmentCollection = openCollections
                //.Where(c => c.SurveyEquipment?.Type == toBeCollected.SurveyEquipment.Type)
                //.Where(c => c.SurveyEquipment.Type.Equals(toBeCollected.SurveyEquipment.Type))
                .Where(c => c.SurveyEquipment?.Type == toBeCollected.SurveyEquipment.Type)
                .SingleOrDefault();
            if (openSurveyEquipmentCollection is not null
                && _kitConstOptions.LimitedSurveyEquipmentTypes.Contains(openSurveyEquipmentCollection.SurveyEquipment.Type.Value))
            {
                if (openSurveyEquipmentCollection.SurveyEquipmentId != toBeCollected.SurveyEquipmentId)
                {
                    throw new CannotCollectSurveyEquipmentException(toBeCollected.SurveyEquipment.Type);
                }
            }

            toBeCollected.Collect(surveyor, collectedAt);
        }
    }
}
