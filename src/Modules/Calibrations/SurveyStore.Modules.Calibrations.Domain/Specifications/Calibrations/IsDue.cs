using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Calibrations.Domain.Specifications.Calibrations
{
    public class IsDue : Specification<Date>
    {
        private readonly Date _calibrationDueDate;
        private readonly Date _now;

        public IsDue(Date calibrationDueDate, Date now)
        {
            _calibrationDueDate = calibrationDueDate;
            _now = now;
        }

        public override Expression<Func<Date, bool>> AsPredicateExpression()
            => isDue => _calibrationDueDate <= (Date)_now.Value.AddDays(7)
                        && _calibrationDueDate > _now;
    }
}
