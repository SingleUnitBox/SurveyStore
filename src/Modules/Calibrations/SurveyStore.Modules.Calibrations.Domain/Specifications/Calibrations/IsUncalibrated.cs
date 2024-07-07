using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace SurveyStore.Modules.Calibrations.Domain.Specifications.Calibrations
{
    public class IsUncalibrated : Specification<Date>
    {
        private readonly Date _calibrationDueDate;
        private readonly Date _now;
        public IsUncalibrated(Date calibrationDueDate, Date now)
        {
            _now = now;
            _calibrationDueDate = calibrationDueDate;
        }

        public override Expression<Func<Date, bool>> AsPredicateExpression()
        {
            return isUncalibrated => _calibrationDueDate <= _now;
        }
    }
}
