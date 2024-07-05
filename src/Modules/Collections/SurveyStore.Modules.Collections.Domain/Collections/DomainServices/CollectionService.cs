using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var surveyEquipmentTypes = openCollections.Select(c => c.SurveyEquipment?.Type);
            foreach (var surveyEquipmentType in surveyEquipmentTypes)
            {
                if (_kitConstOptions.LimitedSurveyEquipmentTypes.Contains(surveyEquipmentType.Value)
                    && toBeCollected.SurveyEquipment.Type.Equals(surveyEquipmentType))
                {
                    throw new CannotCollectSurveyEquipmentException(surveyEquipmentType);
                }               
            }

            toBeCollected.Collect(surveyor, collectedAt);
        }
    }
}
