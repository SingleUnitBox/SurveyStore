using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyorRepository : ISurveyorRepository
    {
        private readonly DbSet<Surveyor> _surveyors;
        private readonly SurveyJobsDbContext _dbContext;

        public PostgresSurveyorRepository(SurveyJobsDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
            _dbContext = dbContext;
        }

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

        public async Task<IReadOnlyCollection<Surveyor>> BrowseAsync()
            => await _surveyors.ToListAsync();

        public Task<Surveyor> GetByIdAsync(AggregateId id)
            => _surveyors.FirstOrDefaultAsync(s => s.Id == id);

        public Task<Surveyor> GetByEmailAsync(string email)
            => _surveyors.FirstOrDefaultAsync(s => s.Email == email);
    }
}