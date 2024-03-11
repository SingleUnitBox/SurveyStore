using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Modules.Equipment.Application.DTO;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.DTO;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories
{
    public class PostgresStoreRepository : IStoreRepository
    {
        private readonly DbSet<Store> _stores;
        private readonly EquipmentDbContext _dbContext;

        public PostgresStoreRepository(EquipmentDbContext dbContext)
        {
            _stores = dbContext.Stores;
            _dbContext = dbContext;
        }

        public async Task<Store> GetByIdAsync(Guid id)
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
