using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Events;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Mappings;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Types;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Commands.Handlers
{
    public class AddGNSSHandler : ICommandHandler<AddGNSS>
    {
        private readonly ISurveyEquipmentRepository _repository;
        private readonly IMessageBroker _messageBroker;

        public AddGNSSHandler(ISurveyEquipmentRepository repository,
            IMessageBroker messageBroker)
        {
            _repository = repository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddGNSS command)
        {
            var gnss = await _repository.GetBySerialNumberAsync(command.SerialNumber);
            if (gnss is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            gnss = command.AsEntity();
            await _repository.AddAsync(gnss);
            await _messageBroker.PublishAsync(new SurveyEquipmentCreated(
                gnss.Id, gnss.SerialNumber, gnss.Brand, gnss.Model, SurveyEquipmentTypes.GNSS));
        }
    }
}
