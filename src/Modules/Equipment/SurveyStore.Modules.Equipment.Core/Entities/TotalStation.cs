namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class TotalStation : SurveyEquipment
    {
        public decimal Accuracy { get; set; }
        public int MaxRemoteDistance { get; set; }
    }
}
