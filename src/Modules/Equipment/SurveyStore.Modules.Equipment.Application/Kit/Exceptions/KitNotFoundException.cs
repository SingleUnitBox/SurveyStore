using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.Exceptions
{
    public sealed class KitNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public string KitType { get; }
        public string SerialNumber { get; }

        public KitNotFoundException(AggregateId id)
            : base($"Kit with id '{id}' was not found.")
        {
            Id = id;
        }

        public KitNotFoundException(string kitType, string serialNumber)
            : base($"'{kitType}' with serial number '{serialNumber}' was not found.")
        {
            KitType = kitType;
            SerialNumber = serialNumber;
        }
    }
}
