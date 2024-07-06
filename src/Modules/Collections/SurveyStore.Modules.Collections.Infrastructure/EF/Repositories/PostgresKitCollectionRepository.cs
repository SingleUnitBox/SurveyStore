using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;
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

        public void Attach(KitCollection kitCollection)
        {
            _dbContext.Entry(kitCollection).State = EntityState.Modified;
        }

        public void Detach(KitCollection kitCollection)
        {
            _dbContext.Entry(kitCollection).State = EntityState.Detached;
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
                //.Include(k => k.Kit)
                .Where(k => k.Surveyor.Id == surveyorId
                && k.CollectedAt != null
                && k.ReturnedAt == null)
                .ToListAsync();

        public async Task<IEnumerable<KitCollection>> BrowseFreeKitCollectionsAsync()
            => await _kitCollections
                //.Include(c => c.Kit)
                .Where(c => c.CollectedAt == null
                    && c.ReturnStoreId == null)
                .ToListAsync();

        public async Task<IEnumerable<KitCollection>> BrowseKitCollectionsAsync(AggregateId kitId)
            => await _kitCollections
                .Include(c => c.Surveyor)
                //.Where(c => c.KitId == kitId)
                .ToListAsync();

        public async Task<IEnumerable<KitCollection>> BrowseAsPredicateExpression(Specification<KitCollection> specification)
            => _kitCollections
                .Include(c => c.Kit)
                .Include(c => c.Surveyor)
                .Where(specification);

        public Task<KitCollection> GetAsPredicateExpression(Specification<KitCollection> specification)
            => _kitCollections
            .Include(k => k.Kit)
            .SingleOrDefaultAsync(specification);
    }
}
