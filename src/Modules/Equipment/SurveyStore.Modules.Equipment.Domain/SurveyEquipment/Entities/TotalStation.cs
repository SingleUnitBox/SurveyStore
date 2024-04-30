using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class TotalStation : SurveyEquipment
    {
        protected TotalStation(AggregateId id) : base(id)
        {
        }

        public decimal Accuracy { get; set; }
        public int MaxRemoteDistance { get; set; }

        public static TotalStation Create(Guid id, string brand, string model, string description, string serialNumber,
            DateTime purchasedAt, decimal accuracy, int maxRemoteDistance)
        {
            var totalStation = new TotalStation(id);
            totalStation.ChangeBrand(brand);
            totalStation.ChangeModel(model);
            totalStation.ChangeDescription(description);
            totalStation.ChangeSerialNumber(serialNumber);
            totalStation.ChangePurchasedAt(purchasedAt);
            totalStation.Accuracy = accuracy;
            totalStation.MaxRemoteDistance = maxRemoteDistance;

            return totalStation;
        }


    }
}
