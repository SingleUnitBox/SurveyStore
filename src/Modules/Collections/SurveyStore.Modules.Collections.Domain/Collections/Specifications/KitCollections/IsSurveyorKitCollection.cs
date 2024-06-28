using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections
{
    public class IsSurveyorKitCollection : Specification<KitCollection>
    {
        private readonly Guid _surveyorId;

        public IsSurveyorKitCollection(Guid surveyorId)
        {
            _surveyorId = surveyorId;
        }
        public override Expression<Func<KitCollection, bool>> AsPredicateExpression()
        {
            return kitCollection => kitCollection.Surveyor.Id == _surveyorId;

        }
    }
}
