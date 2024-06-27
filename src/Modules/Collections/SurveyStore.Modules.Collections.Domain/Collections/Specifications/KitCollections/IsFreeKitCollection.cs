using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsFreeKitCollection : Specification<KitCollection>
    {
        private readonly Guid _kitId;
        public IsFreeKitCollection(Guid kitId)
        {
            _kitId = kitId;
        }

        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
        {
            return kitCollection => kitCollection.KitId == _kitId
                                    && kitCollection.CollectedAt == null
                                    && kitCollection.ReturnedAt == null;
        }
    }
}
