using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Events;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Mappings;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Commands.Handlers
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
                totalStation.Id, totalStation.SerialNumber, totalStation.Brand,
                totalStation.Model, SurveyEquipmentTypes.TotalStation));
        }
    }
}
