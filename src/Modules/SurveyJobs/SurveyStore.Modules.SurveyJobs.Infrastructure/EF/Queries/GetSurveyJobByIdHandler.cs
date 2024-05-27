using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Application.Queries;
using SurveyStore.Modules.SurveyJobs.Application.Mappings;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;
using System.Linq;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Modules.SurveyJobs.Application.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Queries
{
    internal sealed class GetSurveyJobByIdHandler : IQueryHandler<GetSurveyJobById, SurveyJobDto>
    {
        private DbSet<SurveyJob> _surveyJobs;
        public GetSurveyJobByIdHandler(SurveyJobsDbContext dbContext)
        {
            _surveyJobs = dbContext.SurveyJobs;
        }
        public async Task<SurveyJobDto> HandleAsync(GetSurveyJobById query)
        {
            var surveyJob = await _surveyJobs
                .AsNoTracking()
                .Include(sj => sj.Surveyors)
                .Include(sj => sj.Documents)
                .SingleOrDefaultAsync(sj => sj.Id == new AggregateId(query.Id));

            return surveyJob is null 
                ? throw new SurveyJobNotFoundException(query.Id)
                : surveyJob.AsDto();
        }
    }
}