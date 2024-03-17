using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Exceptions;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;
using SurveyStore.Modules.Surveyors.Core.DTO;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Queries.Handlers
{
    public class GetSurveyorByEmailHandler : IQueryHandler<GetSurveyorByEmail, SurveyorDto>
    {
        private readonly DbSet<Surveyor> _surveyors;

        public GetSurveyorByEmailHandler(SurveyorDbContext dbContext)
        {
            _surveyors = dbContext.Surveyors;
        }

        public async Task<SurveyorDto> HandleAsync(GetSurveyorByEmail query)
        {
            var surveyor = await _surveyors
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == query.Email);

            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(query.Email);
            }

            return surveyor.AsDto();
        }
    }
}
