using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Kit
    {
        public KitId Id { get; private set; }
        public Brand Brand { get; private set; }
        public Model Model { get; private set; }
        public SerialNumber SerialNumber { get; private set; }
        public KitType Type { get; private set; }

        private Kit()
        {
            
        }
        protected Kit(KitId id, string brand, string model, string serialNumber, string type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            SerialNumber = serialNumber;
            Type = type;
        }

        public static Kit Create(Guid id, string brand, string model, string serialNumber, string type)
        {
            var kit = new Kit(id, brand, model, serialNumber, type);

            return kit;
        }
    }
}
