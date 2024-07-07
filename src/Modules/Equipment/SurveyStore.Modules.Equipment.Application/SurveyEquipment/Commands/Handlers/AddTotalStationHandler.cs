using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Events;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Mappings;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Types;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Commands.Handlers
{
    public class AddTotalStationHandler : ICommandHandler<AddTotalStation>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IMessageBroker _messageBroker;

        public AddTotalStationHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IMessageBroker messageBroker)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddTotalStation command)
        {
            var totalStation = await _surveyEquipmentRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (totalStation is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            totalStation = TotalStation.Create(command.Id, command.Brand, command.Model, command.Description, 
                command.SerialNumber, command.PurchasedAt, command.Accuracy, command.MaxRemoteDistance);

            await _surveyEquipmentRepository.AddAsync(totalStation);
            await _messageBroker.PublishAsync(new SurveyEquipmentCreated(
                totalStation.Id, totalStation.SerialNumber, totalStation.Brand,
                totalStation.Model, SurveyEquipmentTypes.TotalStation));
        }
    }
}
