using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Application.Mappings;
using SurveyStore.Modules.SurveyJobs.Application.Queries;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Queries
{
    internal sealed class BrowseFreeSurveyJobsHandler
        : IQueryHandler<BrowseFreeSurveyJobs, IReadOnlyCollection<SurveyJobDto>>
    {
        private readonly DbSet<SurveyJob> _surveyJobs;
        public BrowseFreeSurveyJobsHandler(SurveyJobsDbContext dbContext)
        {
            _surveyJobs = dbContext.SurveyJobs;
        }
        public async Task<IReadOnlyCollection<SurveyJobDto>> HandleAsync(BrowseFreeSurveyJobs query)
        {
            var surveyJobs = await _surveyJobs
                .AsNoTracking()
                .Include(sj => sj.Documents)
                .Include(sj => sj.Surveyors)
                .Where(sj => !sj.Surveyors.Any())
                .Select(sj => sj.AsDto())
                .ToListAsync();

            return surveyJobs;
        }
    }
}
