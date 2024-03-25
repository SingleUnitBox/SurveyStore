using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.DAL.Repositories
{
    internal class PostgresStoreRepository : IStoreRepository
    {
        private readonly DbSet<Store> _stores;
        private readonly StoresDbContext _dbContext;

        public PostgresStoreRepository(StoresDbContext dbContext)
        {
            _stores = dbContext.Stores;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Store store)
        {
            await _stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Store> GetByNameAsync(string name)
            => await _stores.SingleOrDefaultAsync(s => s.Name == name);

        public async Task<IReadOnlyList<Store>> BrowseAsync()
            => await _stores
                .OrderBy(s => s.Name)
                .ToListAsync();

        public async Task DeleteAsync(Store store)
        {
            _stores.Remove(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Store> GetAsync(Guid id)
            => await _stores
                .SingleOrDefaultAsync(s => s.Id == id);

        public async Task UpdateAsync(Store store)
        {
            _stores .Update(store);
            await _dbContext.SaveChangesAsync();
        }
    }
}
