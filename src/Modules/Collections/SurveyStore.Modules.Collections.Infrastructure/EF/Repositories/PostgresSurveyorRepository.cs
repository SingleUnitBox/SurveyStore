using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal class PostgresSurveyorRepository : ISurveyorRepository
    {
        private readonly DbSet<Surveyor> _surveyors;
        private readonly CollectionsDbContext _dbContext;

        public PostgresSurveyorRepository(CollectionsDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
            _dbContext = dbContext;
        }
        public async Task AddAsync(Surveyor surveyor)
        {
            await _surveyors.AddAsync(surveyor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Surveyor> GetByIdAsync(SurveyorId id)
            => await _surveyors.SingleOrDefaultAsync(s => s.Id == id);
    }
}
