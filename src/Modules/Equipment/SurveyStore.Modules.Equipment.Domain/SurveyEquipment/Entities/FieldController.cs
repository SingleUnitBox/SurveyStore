using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class FieldController : SurveyEquipment
    {
        public int ScreenSize { get; private set; }
        public void ChangeScreenSize(int screenSize)
        {
            ScreenSize = screenSize;
        }

        protected FieldController(AggregateId id) : base(id)
        {
        }

        public static FieldController Create(Guid id, string brand, string model, string description,
            string serialNumber, DateTime purchasedAt, int screenSize)
        {
            var fieldController = new FieldController(id);
            fieldController.ChangeBrand(brand);
            fieldController.ChangeModel(model);
            fieldController.ChangeDescription(description);
            fieldController.ChangeSerialNumber(serialNumber);
            fieldController.ChangePurchasedAt(purchasedAt);
            fieldController.ChangeScreenSize(screenSize);

            return fieldController;
        }
    }
}
