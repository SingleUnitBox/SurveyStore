using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;

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
            _collections.Update(collection);
            await _dbContext.SaveChangesAsync();
        }
    }
}
