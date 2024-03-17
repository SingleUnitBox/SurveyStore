using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Repositories
{
    public class PostgresSurveyorRepository : ISurveyorRepository
    {
        private readonly DbSet<Surveyor> _surveyors;
        private readonly SurveyorDbContext _dbContext;

        public PostgresSurveyorRepository(SurveyorDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
            _dbContext = dbContext;
        }

        public Task<Surveyor> GetByIdAsync(Guid id)
            => _surveyors.SingleOrDefaultAsync(x => x.Id == id);

        public Task<Surveyor> GetByEmailAsync(string email)
            => _surveyors.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<IReadOnlyCollection<Surveyor>> BrowseAsync()
            => await _surveyors
                .AsNoTracking()
                .ToListAsync();

        public async Task AddAsync(Surveyor surveyor)
        {
            await _surveyors.AddAsync(surveyor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Surveyor surveyor)
        {
            _surveyors.Update(surveyor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Surveyor surveyor)
        {
            _surveyors.Remove(surveyor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
