using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
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
        public Task<IReadOnlyCollection<SurveyJob>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<SurveyJob> GetByIdAsync(AggregateId id)
            => _surveyJobs
                .Include(sj => sj.Surveyor)
                .Include(sj => sj.Documents)
                .FirstOrDefaultAsync(sj => sj.Id == id);
    }
}
