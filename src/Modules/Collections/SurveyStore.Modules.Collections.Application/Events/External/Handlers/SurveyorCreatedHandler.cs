using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class SurveyorCreatedHandler : IEventHandler<SurveyorCreated>
    {
        private readonly ISurveyorRepository _surveyorRepository;

        public SurveyorCreatedHandler(ISurveyorRepository surveyorRepository)
        {
            _surveyorRepository = surveyorRepository;
        }

        public async Task HandleAsync(SurveyorCreated @event)
        {
            var surveyor = Surveyor.Create(@event.Id, @event.FirstName, @event.Surname);

            await _surveyorRepository.AddAsync(surveyor);
        }
    }
}
