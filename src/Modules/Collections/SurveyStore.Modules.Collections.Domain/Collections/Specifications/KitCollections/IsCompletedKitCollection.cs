using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsCompletedKitCollection : Specification<KitCollection>
    {
        private readonly Guid _kitId;
        public IsCompletedKitCollection(Guid kitId)
        {
            _kitId = kitId;
        }
        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
            => kitCollection => kitCollection.Id == _kitId
                                && kitCollection.ReturnedAt != null;
    }
}
