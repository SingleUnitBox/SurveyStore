using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    public class PostgresCollectionRepository : ICollectionRepository
    {
        private readonly DbSet<Collection> _collections;
        private readonly CollectionsDbContext _dbContext;

        public PostgresCollectionRepository(CollectionsDbContext dbContext)
        {
            _collections = dbContext.Collections;
            _dbContext = dbContext;
        }
        public async Task AddAsync(Collection collection)
        {
            await _collections.AddAsync(collection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection collection)
        {
            //_dbContext.ChangeTracker.DetectChanges();

            _collections.Update(collection);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Collection collection)
        {
            _collections.Remove(collection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Collection> GetAsPredicateExpressionAsync(Specification<Collection> specification)
            => await _collections
                .Include(c => c.Surveyor)
                .SingleOrDefaultAsync(specification);

        public async Task<IEnumerable<Collection>> BrowseCollectionsAsync(SurveyEquipmentId surveyEquipmentId)
            => await _collections
                .Include(c => c.Surveyor)
                .Where(c => c.SurveyEquipmentId == surveyEquipmentId.Value)
                .ToListAsync();

        public async Task<IEnumerable<Collection>> BrowseOpenCollectionsBySurveyorIdAsync(SurveyorId surveyorId)
            => await _collections
                //.Include(c => c.SurveyEquipment)
                .Where(c => c.Surveyor.Id == surveyorId
                && c.CollectedAt != null
                && c.ReturnedAt == null)
                .ToListAsync();

        public async Task<IEnumerable<Collection>> BrowseAsPredicateExpressionAsync(Specification<Collection> specification)
            => await _collections
                .Include(c => c.SurveyEquipment)
                .Include(c => c.Surveyor)
                .Where(specification)
                .ToListAsync();
    }
}
