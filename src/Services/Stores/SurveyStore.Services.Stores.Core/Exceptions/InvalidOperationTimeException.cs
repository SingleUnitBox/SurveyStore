using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Core.Exceptions
{
    public class InvalidOperationTimeException : SurveyStoreException
    {
        public DateTime OpeningTime { get; }
        public DateTime ClosingTime { get; }
        public InvalidOperationTimeException(DateTime openingTime, DateTime closingTime)
            : base($"Operation time is invalid for values (from: {openingTime.TimeOfDay} - to: {closingTime.TimeOfDay})")
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }
    }
}
