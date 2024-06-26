﻿using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Services.Stores.Core.Repositories;
using SurveyStore.Services.Stores.Core.Exceptions;

namespace SurveyStore.Services.Stores.Core.Commands.Handlers
{
    public class UpdateStoreHandler : ICommandHandler<UpdateStore>
    {
        private readonly IStoreRepository _storeRepository;

        public UpdateStoreHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task HandleAsync(UpdateStore command)
        {
            var store = await _storeRepository.GetAsync(command.Id);
            if (store is null)
            {
                throw new StoreNotFoundException(command.Id);
            }

            if (command.OpeningTime >= command.ClosingTime)
            {
                throw new InvalidOperationTimeException(command.OpeningTime, command.ClosingTime);
            }

            store.OpeningTime = command.OpeningTime;
            store.ClosingTime = command.ClosingTime;

            await _storeRepository.UpdateAsync(store);
        }
    }
}
