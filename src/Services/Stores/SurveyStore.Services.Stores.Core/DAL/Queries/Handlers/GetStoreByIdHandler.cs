using Microsoft.EntityFrameworkCore;
using SurveyStore.Services.Stores.Core.DTO;
using SurveyStore.Services.Stores.Core.Entities;
using SurveyStore.Services.Stores.Core.Mappings;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Core.DAL.Queries.Handlers
{
    public class GetStoreByIdHandler : IQueryHandler<GetStoreById, StoreDto>
    {
        private readonly DbSet<Store> _stores;
        public GetStoreByIdHandler(StoresDbContext dbContext)
        {
            _stores = dbContext.Stores;
        }

        public async Task<StoreDto> HandleAsync(GetStoreById query)
            => (await _stores
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == query.Id))
                .AsDto();

    }
}
