using System.Threading.Tasks;
using SurveyStore.Modules.Surveyors.Core.Events;
using SurveyStore.Modules.Surveyors.Core.Exceptions;
using SurveyStore.Modules.Surveyors.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Modules.Surveyors.Core.Commands.Handlers
{
    public class AssignDetailsHandler : ICommandHandler<AssignDetails>
    {
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IMessageBroker _messageBroker;

        public AssignDetailsHandler(ISurveyorRepository surveyorRepository,
            IMessageBroker messageBroker)
        {
            _surveyorRepository = surveyorRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AssignDetails command)
        {
            var surveyor = await _surveyorRepository.GetByEmailAsync(command.Email);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.Email);
            }

            surveyor.FirstName = command.FirstName;
            surveyor.Surname = command.Surname;
            surveyor.Position = command.Position ?? "surveyor";

            await _surveyorRepository.UpdateAsync(surveyor);
            await _messageBroker.PublishAsync(
                new SurveyorCreated(surveyor.Id, surveyor.FirstName, surveyor.Surname));
        }
    }
}
