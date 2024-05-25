using SurveyStore.Modules.SurveyJobs.Application.Clients.Surveyors;
using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Events.External.Handlers
{
    public class SurveyorCreatedHandler : IEventHandler<SurveyorCreated>
    {
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ISurveyorsApiClient _surveyorsApiClient;

        public SurveyorCreatedHandler(ISurveyorRepository surveyorRepository,
            ISurveyorsApiClient surveyorsApiClient)
        {
            _surveyorRepository = surveyorRepository;
            _surveyorsApiClient = surveyorsApiClient;
        }

        public async Task HandleAsync(SurveyorCreated @event)
        {
            var surveyor = await _surveyorRepository.GetByIdAsync(@event.Id);
            if (surveyor is not null)
            {
                return;
            }

            var surveyorDto = await _surveyorsApiClient.GetSurveyorAsync(@event.Id);
            if (surveyorDto is null)
            {
                throw new SurveyorNotFoundException(@event.Id);
            }

            surveyor = Surveyor.Create(@event.Id, @event.Email, surveyorDto.FirstName, surveyorDto.Surname);
            await _surveyorRepository.AddAsync(surveyor);
        }
    }
}
