using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Mappings
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
