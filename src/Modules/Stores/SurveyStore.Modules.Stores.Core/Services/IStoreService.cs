﻿using SurveyStore.Modules.Stores.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Services
{
    public interface IStoreService
    {
        Task AddAsync(StoreDto storeDto);
        Task UpdateAsync(StoreDto storeDto);
        Task DeleteAsync(Guid id);
        Task<StoreDto> GetAsync(Guid id);
        Task<IReadOnlyList<StoreDto>> BrowseAsync();
    }
}
