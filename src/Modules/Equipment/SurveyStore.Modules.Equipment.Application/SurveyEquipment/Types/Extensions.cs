using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities;
using SurveyStore.Shared.Abstractions.Types;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Types
{
    public class Extensions
    {
        public static string GetType(object equipment)
            => equipment switch
            {
                TotalStation => SurveyEquipmentTypes.TotalStation,
                GNSS => SurveyEquipmentTypes.GNSS,
                FieldController => SurveyEquipmentTypes.FieldController,
                GroundPenetratingRadar => SurveyEquipmentTypes.GroundPenetratingRadar,
                CableAvoidanceTool => SurveyEquipmentTypes.CAT,
                _ => throw new SurveyEquipmentTypeNotFoundException(equipment.GetType().Name)
            };
    }
}
