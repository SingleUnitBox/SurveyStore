using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Modules.Equipment.Domain.Kit.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories
{
    internal sealed class PostgresKitRepository : IKitRepository
    {
        private readonly DbSet<Kit> _kit;
        private readonly EquipmentDbContext _dbContext;
        public PostgresKitRepository(EquipmentDbContext dbContext)
        {
            _kit = dbContext.Kit;
            _dbContext = dbContext;

        }
        public async Task AddAsync(Kit kit)
        {
            await _kit.AddAsync(kit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kit kit)
        {
            _kit.Update(kit);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Kit> GetByIdAsync(Guid id)
            => _kit.SingleOrDefaultAsync(k => k.Id == id);

        public Task<Kit> GetBySerialNumberAsync(string serialNumber)
            => _kit.SingleOrDefaultAsync(k => k.SerialNumber == serialNumber);

        public async Task<IReadOnlyCollection<Kit>> BrowseAsync()
            => await _kit
                .AsNoTracking()
                .ToListAsync();
    }
}
