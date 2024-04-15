using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.Entities
{
    public class SurveyEquipment
    {
        public SurveyEquipmentId Id { get; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }

        internal SurveyEquipment(SurveyEquipmentId id)
        {
            Id = id;
        }

        public void ChangeDetails(string brand, string model, string serialNumber)
        {
            Brand = brand;
            Model = model;
            SerialNumber = serialNumber;
        }

        public static SurveyEquipment Create(Guid id, string brand, string model, string serialNumber)
        {
            var surveyEquipment = new SurveyEquipment(id);
            surveyEquipment.ChangeDetails(brand, model, serialNumber);

            return surveyEquipment;
        }
    }
}
