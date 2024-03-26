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
    }
}