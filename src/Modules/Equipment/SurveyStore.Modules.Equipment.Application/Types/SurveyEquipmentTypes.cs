using SurveyStore.Modules.Equipment.Application.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.Types
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
                Core.Entities.TotalStation => TotalStation,
                Core.Entities.GNSS => GNSS,
                Core.Entities.FieldController => FieldController,
                Core.Entities.GroundPenetratingRadar => GroundPenetratingRadar,
                Core.Entities.CableAvoidanceTool => CAT,
                _ => throw new SurveyEquipmentTypeNotFoundException(equipment.GetType().Name)
            };
    }
}
