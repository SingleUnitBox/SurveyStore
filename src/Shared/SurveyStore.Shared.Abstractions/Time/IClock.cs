using System;

namespace SurveyStore.Shared.Abstractions.Time
{
    public interface IClock
    {
        DateTime Current();
    }
}
