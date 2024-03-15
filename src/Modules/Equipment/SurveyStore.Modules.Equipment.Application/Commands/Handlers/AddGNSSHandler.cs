using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddGNSSHandler : ICommandHandler<AddGNSS>
    {
        private readonly ISurveyEquipmentRepository _repository;

        public AddGNSSHandler(ISurveyEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddGNSS command)
        {
            var gnss = await _repository.GetBySerialNumberAsync(command.SerialNumber);
            if (gnss is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            //gnss = command.AsEntity();
            await _repository.AddAsync(gnss);
        }
    }
}
