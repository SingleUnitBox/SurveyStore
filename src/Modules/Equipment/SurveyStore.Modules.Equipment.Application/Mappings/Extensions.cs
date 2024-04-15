using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Types;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Application.Mappings
{
    public static class Extensions
    {

        public static SurveyEquipmentDto AsDto(this SurveyEquipment equipment)
            => new()
            {
                Id = equipment.Id,
                Brand = equipment.Brand,
                Model = equipment.Model,
                Description = equipment.Description,
                SerialNumber = equipment.SerialNumber,
                PurchasedAt = equipment.PurchasedAt,
                Accuracy = equipment is TotalStation ts ? ts.Accuracy : null,
                MaxRemoteDistance = equipment is TotalStation tst ? tst.MaxRemoteDistance : null,
                IsActive = equipment is GNSS g ? g.IsActive : null,
                ScreenSize = equipment is FieldController f ? f.ScreenSize : null,
                Frequency = equipment is GroundPenetratingRadar gpr ? gpr.Frequency : null,
                OffRoadMode = equipment is GroundPenetratingRadar gp ? gp.OffRoadMode : null,
                Type = equipment switch
                {
                    TotalStation => SurveyEquipmentTypes.TotalStation,
                    GNSS => SurveyEquipmentTypes.GNSS,
                    FieldController => SurveyEquipmentTypes.FieldController,
                    GroundPenetratingRadar => SurveyEquipmentTypes.GroundPenetratingRadar,
                    CableAvoidanceTool => SurveyEquipmentTypes.CAT,
                    _ => null
                }
            };

        public static TotalStation AsEntity(this AddTotalStation command)
            => TotalStation.Create(command.Id, command.Brand, command.Model, command.Description, command.SerialNumber,
                command.PurchasedAt, command.Accuracy, command.MaxRemoteDistance);

        //public static GNSS AsEntity(this AddGNSS command)
        //    => new()
        //    {
        //        Id = command.Id,
        //        Brand = command.Brand,
        //        Model = command.Model,
        //        Description = command.Description,
        //        SerialNumber = command.SerialNumber,
        //        PurchasedAt = command.PurchasedAt,
        //        CalibrationDate = command.CalibrationDate,
        //        CalibrationInterval = command.CalibrationInterval,
        //        IsActive = command.IsActive ?? false,
        //    };

        //public static FieldController AsEntity(this AddFieldController command)
        //    => new()
        //    {
        //        Id = command.Id,
        //        Brand = command.Brand,
        //        Model = command.Model,
        //        Description = command.Description,
        //        SerialNumber = command.SerialNumber,
        //        PurchasedAt = command.PurchasedAt,
        //        CalibrationDate = command.CalibrationDate,
        //        CalibrationInterval = command.CalibrationInterval,
        //        ScreenSize = command.ScreenSize,
        //    };
    }
}
