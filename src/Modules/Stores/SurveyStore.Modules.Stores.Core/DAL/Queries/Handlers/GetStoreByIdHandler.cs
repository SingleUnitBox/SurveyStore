using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Mappings;
using SurveyStore.Shared.Abstractions.Queries;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.DAL.Queries.Handlers
{
    public class GetStoreByIdHandler : IQueryHandler<GetStoreById, StoreDto>
    {
        private readonly DbSet<Store> _stores;
        public GetStoreByIdHandler(StoresDbContext dbContext)
        {
            _stores = dbContext.Stores;
        }

        public async Task<StoreDto> HandleAsync(GetStoreById query)
        {
            var store = await _stores
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == query.Id);
            return store is null ? throw new StoreNotFoundException(query.Id) : store.AsDto();
        }

    }
}
