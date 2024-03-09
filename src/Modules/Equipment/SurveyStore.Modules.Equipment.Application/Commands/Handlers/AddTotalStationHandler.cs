using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddTotalStationHandler : ICommandHandler<AddTotalStation>
    {
        private readonly ISurveyEquipmentRepository _surveyRepository;

        public AddTotalStationHandler(ISurveyEquipmentRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task HandleAsync(AddTotalStation command)
        {
            var totalStation = await _surveyRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (totalStation is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            totalStation = command.AsEntity();
            await _surveyRepository.AddAsync(totalStation);
        }
    }
}
