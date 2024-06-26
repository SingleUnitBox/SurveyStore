using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class SurveyEquipment
    {
        public SurveyEquipmentId Id { get; private set; }
        public SerialNumber SerialNumber { get; private set; }
        public Brand Brand { get; private set; }
        public Model Model { get; private set; }
        public SurveyEquipmentType Type { get; private set; }

        private SurveyEquipment()
        {
            
        }

        private SurveyEquipment(SurveyEquipmentId id, SerialNumber serialNumber,
            Brand brand, Model model, SurveyEquipmentType type)
        {
            Id = id;
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
            Type = type;
        }

        public static SurveyEquipment Create(Guid id, string serialNumber, string brand, string model, string type)
        {
            var equipment = new SurveyEquipment(id, serialNumber, brand, model, type);

            return equipment;
        }
    }
}