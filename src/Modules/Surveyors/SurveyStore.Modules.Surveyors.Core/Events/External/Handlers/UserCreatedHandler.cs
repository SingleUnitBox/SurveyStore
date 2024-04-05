using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Repositories;

namespace SurveyStore.Modules.Surveyors.Core.Events.External.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly ISurveyorRepository _surveyorRepository;

        public UserCreatedHandler(ISurveyorRepository surveyorRepository)
        {
            _surveyorRepository = surveyorRepository;
        }
        public async Task HandleAsync(UserCreated @event)
        {
            var surveyor = Surveyor.Create(@event.Id, @event.Email);

            await _surveyorRepository.AddAsync(surveyor);
        }
    }
}
