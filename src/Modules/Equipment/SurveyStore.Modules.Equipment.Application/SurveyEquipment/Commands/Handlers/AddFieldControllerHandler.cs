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
    public class AddFieldControllerHandler : ICommandHandler<AddFieldController>
    {
        private readonly ISurveyEquipmentRepository _surveyRepository;
        private readonly IMessageBroker _messageBroker;

        public AddFieldControllerHandler(ISurveyEquipmentRepository surveyRepository,
            IMessageBroker messageBroker)
        {
            _surveyRepository = surveyRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddFieldController command)
        {
            var controller = await _surveyRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (controller is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            controller = command.AsEntity();
            await _surveyRepository.AddAsync(controller);
            await _messageBroker.PublishAsync(new SurveyEquipmentCreated(controller.Id, controller.SerialNumber,
                controller.Brand, controller.Model, SurveyEquipmentTypes.FieldController));
        }
    }
}
