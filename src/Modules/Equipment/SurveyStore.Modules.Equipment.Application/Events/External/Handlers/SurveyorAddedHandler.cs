using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Events.External.Handlers
{
    public class SurveyorAddedHandler : IEventHandler<SurveyorAdded>
    {
        private readonly ISurveyorRepository _surveyorRepository;

        public SurveyorAddedHandler(ISurveyorRepository surveyorRepository)
        {
            _surveyorRepository = surveyorRepository;
        }

        public async Task HandleAsync(SurveyorAdded @event)
        {
            var surveyor = new Surveyor
            {
                Id = @event.Id,
                FullName = @event.FirstName + " " + @event.Surname,
            };

            await _surveyorRepository.AddAsync(surveyor);
        }
    }
}
