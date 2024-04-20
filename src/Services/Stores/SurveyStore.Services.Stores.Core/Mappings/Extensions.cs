using SurveyStore.Services.Stores.Core.DTO;
using SurveyStore.Services.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Core.Mappings
{
    public static class Extensions
    {
        public static StoreDto AsDto(this Store store)
            => new()
            {
                Id = store.Id,
                Name = store.Name,
                Location = store.Location,
                OpeningTime = store.OpeningTime,
                ClosingTime = store.ClosingTime,
            };
    }
}
