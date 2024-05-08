using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal sealed class PostgresKitRepository : IKitRepository
    {
        private DbSet<Kit> _kit;
        private CollectionsDbContext _dbContext;

        public PostgresKitRepository(CollectionsDbContext dbContext)
        {
            _kit = dbContext.Kit;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Kit kit)
        {
            await _kit.AddAsync(kit);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Kit> GetAsync(AggregateId id)
            => _kit.SingleOrDefaultAsync(k => k.Id == id);

        public Task<Kit> GetBySerialNumberAsync(string serialNumber)
            => _kit.SingleOrDefaultAsync(k => k.SerialNumber == serialNumber);
    }
}
