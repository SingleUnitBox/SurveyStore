using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class TotalStation : SurveyEquipment
    {
        protected TotalStation(AggregateId id) : base(id)
        {
        }

        public decimal Accuracy { get; set; }
        public int MaxRemoteDistance { get; set; }

        public static TotalStation Create(string brand, string model, string description, string serialNumber, DateTime purchasedAt,
            DateTime? calibrationDate, TimeSpan? calibrationInterval, decimal accuracy, int maxRemoteDistance)
        {
            var totalStation = new TotalStation(Guid.NewGuid());
            totalStation.ChangeBrand(brand);
            totalStation.ChangeModel(model);
            totalStation.ChangeDescription(description);
            totalStation.ChangeSerialNumber(serialNumber);
            totalStation.ChangePurchasedAt(purchasedAt);
            if (calibrationDate.HasValue)
            {
                totalStation.ChangeCalibrationDate(calibrationDate.Value);
            }

            if (calibrationInterval.HasValue)
            {
                totalStation.ChangeCalibrationInterval(calibrationInterval.Value);
            }

            totalStation.Accuracy = accuracy;
            totalStation.MaxRemoteDistance = maxRemoteDistance;

            return totalStation;
        }


    }
}
