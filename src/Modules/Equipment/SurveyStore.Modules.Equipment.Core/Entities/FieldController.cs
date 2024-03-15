using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class FieldController : SurveyEquipment
    {
        public int ScreenSize { get; set; }

        protected FieldController(AggregateId id) : base(id)
        {
        }
    }
}
