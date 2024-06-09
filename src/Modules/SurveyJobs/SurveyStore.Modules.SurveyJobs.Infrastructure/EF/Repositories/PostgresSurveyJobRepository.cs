using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyJobRepository : ISurveyJobRepository
    {
        private readonly DbSet<SurveyJob> _surveyJobs;
        private readonly SurveyJobsDbContext _dbContext;

        public PostgresSurveyJobRepository(SurveyJobsDbContext dbContext)
        {
            _surveyJobs = dbContext.SurveyJobs;
            _dbContext = dbContext;
        }

        public async Task AddAsync(SurveyJob surveyJob)
        {
            await _surveyJobs.AddAsync(surveyJob);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SurveyJob surveyJob)
        {
            _surveyJobs.Update(surveyJob);
            await _dbContext.SaveChangesAsync();
        }

        public Task<SurveyJob> GetByIdAsync(AggregateId id)
            => _surveyJobs
                .Include(sj => sj.Surveyors)
                .Include(sj => sj.Documents)
                .FirstOrDefaultAsync(sj => sj.Id == id);

        public async Task<IEnumerable<SurveyJob>> BrowseAsync()
            => await _surveyJobs
                .ToListAsync();
                

        public async Task<IReadOnlyCollection<SurveyJob>> BrowseForSurveyorAsync(Guid surveyorId)
            => (await _surveyJobs
                .AsNoTracking()
                .Include(sj => sj.Surveyors)
                .Where(sj => sj.Surveyors.Any(s => s.Id == surveyorId))
                .ToListAsync())
                .AsReadOnly();
    }
}