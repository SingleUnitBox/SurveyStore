using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Types
{
    public class SurveyEquipmentTypes
    {
        public const string TotalStation = "total station";
        public const string GNSS = "gnss";
        public const string FieldController = "field controller";
        public const string GroundPenetratingRadar = "ground penetrating radar";
        public const string CAT = "cable avoidance tool";

        public static string GetType(object equipment)
            => equipment switch
            {
                Domain.SurveyEquipment.Entities.TotalStation => TotalStation,
                Domain.SurveyEquipment.Entities.GNSS => GNSS,
                Domain.SurveyEquipment.Entities.FieldController => FieldController,
                Domain.SurveyEquipment.Entities.GroundPenetratingRadar => GroundPenetratingRadar,
                Domain.SurveyEquipment.Entities.CableAvoidanceTool => CAT,
                _ => throw new SurveyEquipmentTypeNotFoundException(equipment.GetType().Name)
            };
    }
}
