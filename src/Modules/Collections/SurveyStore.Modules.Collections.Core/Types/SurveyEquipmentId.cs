using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Core.Types
{
    public class SurveyEquipmentId : TypeId
    {
        public SurveyEquipmentId(Guid value) : base(value)
        {
        }

        public static implicit operator SurveyEquipmentId(Guid id) => new(id);
    }
}
