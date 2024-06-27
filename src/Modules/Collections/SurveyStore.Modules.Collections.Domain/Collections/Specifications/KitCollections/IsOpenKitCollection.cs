using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsOpenKitCollection : Specification<KitCollection>
    {
        private readonly Guid _kitId;
        public IsOpenKitCollection(Guid kitId)
        {
            _kitId = kitId;
        }
        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
            => kitCollection => kitCollection.Id == _kitId
                                && kitCollection.CollectedAt != null
                                && kitCollection.ReturnedAt == null;
    }
}
