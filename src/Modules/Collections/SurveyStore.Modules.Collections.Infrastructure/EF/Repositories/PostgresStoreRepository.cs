using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal class PostgresStoreRepository : IStoreRepository
    {
        private readonly DbSet<Store> _stores;
        private readonly CollectionsDbContext _dbContext;

        public PostgresStoreRepository(CollectionsDbContext dbContext)
        {
            _stores = dbContext.Stores;
            _dbContext = dbContext;
        }

        public async Task<Store> GetByIdAsync(StoreId id)
            => await _stores.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<Store> GetByNameAsync(string name)
            => await _stores.SingleOrDefaultAsync(s => s.Name == name);

        public async Task AddAsync(Store store)
        {
            await _stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Store store)
        {
            _stores.Update(store);
            await _dbContext.SaveChangesAsync();
        }
    }
}
