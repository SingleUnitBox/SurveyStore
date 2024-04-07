using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Application.Mappings
{
    public static class Extensions
    {
        public static StoreDto AsDto(this Store store)
            => new()
            {
                Id = store.Id,
                Name = store.Name
            };

        public static SurveyEquipmentDto AsDto(this SurveyEquipment surveyEquipment)
            => new()
            {
                Id = surveyEquipment.Id,
                SerialNumber = surveyEquipment.SerialNumber,
                Brand = surveyEquipment.Brand,
                Model = surveyEquipment.Model,
            };

        public static SurveyEquipmentDetailsDto AsDetailsDto(this SurveyEquipment surveyEquipment)
            => new()
            {
                Id = surveyEquipment.Id,
                SerialNumber = surveyEquipment.SerialNumber,
                Brand = surveyEquipment.Brand,
                Model = surveyEquipment.Model,
                Store = surveyEquipment?.Store?.AsDto()
            };
    }
}