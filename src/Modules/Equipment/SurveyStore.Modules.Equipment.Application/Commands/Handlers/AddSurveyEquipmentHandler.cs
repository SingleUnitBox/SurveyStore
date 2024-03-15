using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddSurveyEquipmentHandler : ICommandHandler<AddSurveyEquipment>
    {
        private readonly ISurveyEquipmentRepository _surveyRepository;

        public AddSurveyEquipmentHandler(ISurveyEquipmentRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task HandleAsync(AddSurveyEquipment command)
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
