using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class FieldController : SurveyEquipment
    {
        public int ScreenSize { get; set; }

        protected FieldController(AggregateId id) : base(id)
        {
        }
    }
}
