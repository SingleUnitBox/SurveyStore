using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Application.Mappings
{
    public static class Extensions
    {
        public static TotalStation AsEntity(this AddTotalStation command)
            => new()
            {
                Id = command.Id,
                Brand = command.Brand,
                Model = command.Model,
                Description = command.Description,
                SerialNumber = command.SerialNumber,
                PurchasedAt = command.PurchasedAt,
                CalibrationDate = command.CalibrationDate,
                CalibrationInterval = command.CalibrationInterval,
                Accuracy = command.Accuracy ?? 0,
                MaxRemoteDistance = command.MaxRemoteDistance
            };
    }
}
