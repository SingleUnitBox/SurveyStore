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
    internal class BrowseSurveyJobsBySurveyorHandler : IQueryHandler<BrowseSurveyJobsBySurveyor, IEnumerable<SurveyJobDto>>
    {
        private readonly DbSet<SurveyJob> _surveyJobs;
        public BrowseSurveyJobsBySurveyorHandler(SurveyJobsDbContext dbContext)
        {
            _surveyJobs = dbContext.SurveyJobs;
        }
        public async Task<IEnumerable<SurveyJobDto>> HandleAsync(BrowseSurveyJobsBySurveyor query)
        {
            var surveyJobs = await _surveyJobs
                .AsNoTracking()
                .Include(sj => sj.Surveyors)
                .Include(sj => sj.Documents)
                .Where(sj => sj.Surveyors.Any(s => s.Email == query.Email))
                .Select(sj => sj.AsDto())
                .ToListAsync();

            return surveyJobs;
        }
    }
}
