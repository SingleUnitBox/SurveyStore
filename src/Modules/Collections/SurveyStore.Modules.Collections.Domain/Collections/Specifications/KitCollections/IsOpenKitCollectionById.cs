using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsOpenKitCollectionById : Specification<KitCollection>
    {
        private readonly Guid _kitId;
        public IsOpenKitCollectionById(Guid kitId)
        {
            _kitId = kitId;
        }
        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
            => kitCollection => kitCollection.KitId == _kitId
                                && kitCollection.CollectedAt != null
                                && kitCollection.ReturnedAt == null;
    }
}
