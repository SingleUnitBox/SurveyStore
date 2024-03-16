using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddTotalStationHandler : ICommandHandler<AddTotalStation>
    {
        private readonly ISurveyEquipmentRepository _repository;
        private readonly IStoreRepository _storeRepository;

        public AddTotalStationHandler(ISurveyEquipmentRepository repository,
            IStoreRepository storeRepository)
        {
            _repository = repository;
            _storeRepository = storeRepository;
        }

        public async Task HandleAsync(AddTotalStation command)
        {
            var totalStation = await _repository.GetBySerialNumberAsync(command.SerialNumber);
            if (totalStation is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            totalStation = command.AsEntity();

            if (!string.IsNullOrWhiteSpace(command.StoreName))
            {
                var store = await _storeRepository.GetByNameAsync(command.StoreName);
                if (store is null)
                {
                    throw new StoreNotFoundException(command.StoreName);
                }

                totalStation.Store = store;
            }

            await _repository.AddAsync(totalStation);
        }
    }
}
