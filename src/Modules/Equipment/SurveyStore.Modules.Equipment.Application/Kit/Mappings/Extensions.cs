using SurveyStore.Modules.Equipment.Application.Kit.DTO;

namespace SurveyStore.Modules.Equipment.Application.Kit.Mappings
{
    public static class Extensions
    {
        public static KitDto AsDto(this Domain.Kit.Entities.Kit kit)
            => new KitDto()
            {
                Id = kit.Id,
                Brand = kit.Brand,
                Model = kit.Model,
                SerialNumber = kit.SerialNumber,
                PurchasedAt = kit.PurchasedAt,
                Type = kit.GetType().Name
            };
    }
}
