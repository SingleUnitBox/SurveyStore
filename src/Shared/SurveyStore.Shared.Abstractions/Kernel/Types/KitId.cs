using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class KitId : TypeId
    {
        public KitId(Guid value) : base(value)
        {
            
        }

        public static implicit operator KitId(Guid value) => new(value);
        public static implicit operator Guid(KitId id) => id.Value;
        public override string ToString()
            => this.Value.ToString();
    }
}
