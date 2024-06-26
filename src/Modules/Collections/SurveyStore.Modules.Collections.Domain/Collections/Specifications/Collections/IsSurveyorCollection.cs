using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections
{
    public class IsSurveyorCollection : Specification<Collection>
    {
        private readonly Guid _surveyorId;

        public IsSurveyorCollection(Guid surveyorId)
        {
            _surveyorId = surveyorId;
        }

        public override Expression<Func<Collection, bool>> AsPredicateExpression()
            => collection => collection.Surveyor.Id == _surveyorId;
    }
}
