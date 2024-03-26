using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class StoreId : TypeId
    {
        public StoreId(Guid value) : base(value)
        {
            
        }

        public static implicit operator Guid(StoreId id) => id.Value;
        public static implicit operator StoreId(Guid value) => new(value);
    }
}
