using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Mappings;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.DAL.Queries.Handlers
{
    public class BrowseStoresHandler : IQueryHandler<BrowseStores, IReadOnlyCollection<StoreDto>>
    {
        private readonly DbSet<Store> _stores;
        public BrowseStoresHandler(StoresDbContext dbContext)
        {
            _stores = dbContext.Stores;
        }
        public async Task<IReadOnlyCollection<StoreDto>> HandleAsync(BrowseStores query)
            => await _stores
                .AsNoTracking()
                .Select(s => s.AsDto())
                .ToListAsync();
    }
}
