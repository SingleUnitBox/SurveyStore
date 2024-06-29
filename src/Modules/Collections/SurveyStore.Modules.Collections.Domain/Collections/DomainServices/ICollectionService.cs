using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface ICollectionService
    {
        void Collect(IEnumerable<Collection> openCollections, Collection toBeCollected,
            Surveyor surveyor, Date collectedAt);
    }
}
