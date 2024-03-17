using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyorRepository : ISurveyorRepository
    {
        private readonly DbSet<Surveyor> _surveyors;
        private readonly EquipmentDbContext _dbContext;

        public PostgresSurveyorRepository(EquipmentDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Surveyor surveyor)
        {
            await _surveyors.AddAsync(surveyor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
