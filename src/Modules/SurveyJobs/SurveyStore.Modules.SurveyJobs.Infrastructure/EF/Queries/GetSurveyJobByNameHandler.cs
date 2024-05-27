using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Application.Queries;
using SurveyStore.Modules.SurveyJobs.Application.Mappings;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;
using SurveyStore.Modules.SurveyJobs.Application.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Queries
{
    internal sealed class GetSurveyJobByNameHandler : IQueryHandler<GetSurveyJobByName, SurveyJobDto>
    {
        private DbSet<SurveyJob> _surveyJobs;
        public GetSurveyJobByNameHandler(SurveyJobsDbContext dbContext)
        {
            _surveyJobs = dbContext.SurveyJobs;
        }
        public async Task<SurveyJobDto> HandleAsync(GetSurveyJobByName query)
        {
            var surveyJob = await _surveyJobs
                .AsNoTracking()
                .Include(sj => sj.Surveyors)
                .Include(sj => sj.Documents)
                .SingleOrDefaultAsync(sj => sj.Name == query.Name);

            return surveyJob is null
                ? throw new SurveyJobNotFoundException(query.Name)
                : surveyJob.AsDto();
        }
    }
}