using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Events;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddTotalStationHandler : ICommandHandler<AddTotalStation>
    {
        private readonly ISurveyEquipmentRepository _repository;
        private readonly IMessageBroker _messageBroker;

        public AddTotalStationHandler(ISurveyEquipmentRepository repository,
            IMessageBroker messageBroker)
        {
            _repository = repository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddTotalStation command)
        {
            var totalStation = await _repository.GetBySerialNumberAsync(command.SerialNumber);
            if (totalStation is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            totalStation = command.AsEntity();

            await _repository.AddAsync(totalStation);
            await _messageBroker.PublishAsync(new SurveyEquipmentCreated(
                totalStation.Id, totalStation.SerialNumber, totalStation.Brand, totalStation.Model));
        }
    }
}
