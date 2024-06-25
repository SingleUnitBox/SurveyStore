using SurveyStore.Modules.Collections.Application.Clients.Surveyors;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
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

            surveyor = Surveyor.Create(surveyorDto.Id, surveyorDto.FirstName, surveyorDto.Surname);

            await _surveyorRepository.AddAsync(surveyor);

            _surveyorsApiClient.CreateSurveyorAsync(Guid.NewGuid());
        }
    }
}
