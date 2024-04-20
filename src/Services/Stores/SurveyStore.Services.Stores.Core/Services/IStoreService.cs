using SurveyStore.Services.Stores.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Core.Services
{
    public interface IStoreService
    {
        Task<StoreDto> GetAsync(Guid id);
        Task<IReadOnlyList<StoreDto>> BrowseAsync();
    }
}
