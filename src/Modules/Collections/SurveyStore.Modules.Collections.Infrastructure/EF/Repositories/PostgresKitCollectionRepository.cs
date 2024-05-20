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

        public async Task UpdateRangeAsync(IEnumerable<KitCollection> kitCollections)
        {
            _kitCollections.UpdateRange(kitCollections);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<KitCollection>> BrowseOpenKitCollectionsBySurveyorAsync(SurveyorId surveyorId)
            => await _kitCollections
                .Include(k => k.Surveyor)
                .Include(k => k.Kit)
                .Where(k => k.Surveyor.Id == surveyorId
                && k.CollectedAt != null
                && k.ReturnedAt == null)
                .ToListAsync();

        public async Task<IEnumerable<KitCollection>> BrowseFreeKitCollectionsAsync()
            => await _kitCollections
                .Include(c => c.Kit)
                .Where(c => c.CollectedAt == null
                    && c.ReturnStoreId == null)
                .ToListAsync();

        public async Task<IEnumerable<KitCollection>> BrowseKitCollectionsAsync(AggregateId kitId)
            => await _kitCollections
                .Include(c => c.Surveyor)
                .Where(c => c.KitId == kitId)
                .ToListAsync();

        public async Task<KitCollection> GetFreeByKitAsync(AggregateId kitId)
            //=> await _kitCollections
            //    .Include(c => c.Kit)
            //    .SingleOrDefaultAsync(c => c.KitId == kitId
            //    && c.CollectedAt == null
            //    && c.ReturnedAt == null);

            => await _kitCollections
                .Where(c => c.KitId == kitId
                            && c.ReturnStoreId == null
                            && c.CollectedAt == null)
                .Include(c => c.Kit)
                .SingleOrDefaultAsync();

        public Task<KitCollection> GetOpenByKitAsync(AggregateId kitId)
            => _kitCollections
                .Include(c => c.Kit)
                .SingleOrDefaultAsync(c => c.KitId == kitId
                && c.CollectedAt != null
                && c.ReturnedAt == null);
    }
}
