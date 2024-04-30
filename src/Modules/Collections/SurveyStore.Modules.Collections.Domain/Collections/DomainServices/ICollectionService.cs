using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainServices
{
    public interface ICollectionService
    {
        void Collect(IEnumerable<Collection> openCollections, Surveyor surveyor,
            Collection toBeCollected, DateTime now);
    }
}
