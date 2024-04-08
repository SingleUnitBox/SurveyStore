using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Exceptions;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Queries.Handlers
{
    public class GetSurveyorByIdHandler : IQueryHandler<GetSurveyorById, SurveyorDto>
    {
        private readonly DbSet<Surveyor> _surveyors;

        public GetSurveyorByIdHandler(SurveyorDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
        }
        public async Task<SurveyorDto> HandleAsync(GetSurveyorById query)
        {
            //var surveyor = await _surveyors
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(s => s.Id == query.Id);
            //if (surveyor is null)
            //{
            //    throw new SurveyorNotFoundException(query.Id);
            //}

            //return surveyor.AsDto();

            var surveyor = await _surveyors
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == query.Id);

            return surveyor is not null ? surveyor.AsDto() : throw new SurveyorNotFoundException(query.Id);
        }
    }
}
