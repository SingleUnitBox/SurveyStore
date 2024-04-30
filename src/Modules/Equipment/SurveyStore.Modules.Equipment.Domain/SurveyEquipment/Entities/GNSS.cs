using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class GNSS : SurveyEquipment
    {
        public bool IsActive { get; set; }

        protected GNSS(AggregateId id) : base(id)
        {
        }

        public static GNSS Create(Guid id, string brand, string model, string description, string serialNumber,
            DateTime purchasedAt, bool isActive)
        {
            var gnss = new GNSS(id);
            gnss.ChangeBrand(brand);
            gnss.ChangeModel(model);
            gnss.ChangeDescription(description);
            gnss.ChangeSerialNumber(serialNumber);
            gnss.ChangePurchasedAt(purchasedAt);
            gnss.IsActive = isActive;

            return gnss;
        }
    }
}
