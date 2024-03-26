using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Types
{
    public class StoreId : TypeId
    {
        public StoreId(Guid value) : base(value)
        {
            
        }

        public static implicit operator StoreId(Guid value) => new(value);
    }
}
