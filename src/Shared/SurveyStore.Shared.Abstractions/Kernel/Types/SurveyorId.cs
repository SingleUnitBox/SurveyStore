using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class SurveyorId : TypeId
    {
        public SurveyorId(Guid value) : base(value)
        {
        }

        public static implicit operator Guid(SurveyorId id) => id.Value;
        public static implicit operator SurveyorId(Guid value) => new(value);
    }
}
