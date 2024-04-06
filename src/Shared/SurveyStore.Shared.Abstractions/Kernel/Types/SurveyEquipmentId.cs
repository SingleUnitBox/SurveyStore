using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class SurveyEquipmentId : TypeId
    {
        public SurveyEquipmentId(Guid value) : base(value)
        {
        }

        public static implicit operator SurveyEquipmentId(Guid id) => new SurveyEquipmentId(id);
        public static implicit operator Guid(SurveyEquipmentId id) => id.Value;
    }
}
