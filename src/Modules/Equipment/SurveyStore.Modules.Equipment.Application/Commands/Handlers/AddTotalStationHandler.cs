using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddTotalStationHandler : ICommandHandler<AddTotalStation>
    {
        private readonly ISurveyEquipmentRepository _repository;

        public AddTotalStationHandler(ISurveyEquipmentRepository repository)
        {
            _repository = repository;
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
        }
    }
}
