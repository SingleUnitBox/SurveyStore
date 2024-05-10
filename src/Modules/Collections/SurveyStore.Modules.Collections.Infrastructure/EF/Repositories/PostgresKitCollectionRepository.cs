using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal sealed class PostgresKitCollectionRepository : IKitCollectionRepository
    {
        private readonly DbSet<KitCollection> _kitCollections;
        private readonly CollectionsDbContext _dbContext;

        public PostgresKitCollectionRepository(CollectionsDbContext dbContext)
        {
            _kitCollections = dbContext.KitCollections;
            _dbContext = dbContext;
        }

        public async Task AddAsync(KitCollection kitCollection)
        {
            await _kitCollections.AddAsync(kitCollection);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(KitCollection kitCollection)
        {
            _kitCollections.Update(kitCollection);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<KitCollection>> BrowseKitCollectionsAsync(AggregateId kitId)
            => await _kitCollections
                .Where(c => c.KitId == kitId)
                .ToListAsync();

        public Task<KitCollection> GetFreeByKitAsync(AggregateId kitId)
            => _kitCollections
                .Include(c => c.Kit)
                .SingleOrDefaultAsync(c => c.KitId == kitId
                && c.CollectedAt == null
                && c.ReturnedAt == null);

        public Task<KitCollection> GetOpenByKitAsync(AggregateId kitId)
            => _kitCollections
                .Include(c => c.Kit)
                .SingleOrDefaultAsync(c => c.KitId == kitId
                && c.CollectedAt != null
                && c.ReturnedAt == null);
    }
}
