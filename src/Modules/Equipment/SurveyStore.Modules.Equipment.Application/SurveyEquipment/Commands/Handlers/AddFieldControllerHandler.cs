using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Commands.Handlers
{
    public class AddFieldControllerHandler : ICommandHandler<AddFieldController>
    {
        private readonly ISurveyEquipmentRepository _surveyRepository;

        public AddFieldControllerHandler(ISurveyEquipmentRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task HandleAsync(AddFieldController command)
        {
            var equipment = await _surveyRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (equipment is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            //equipment = command.AsEntity();
            await _surveyRepository.AddAsync(equipment);
        }
    }
}
