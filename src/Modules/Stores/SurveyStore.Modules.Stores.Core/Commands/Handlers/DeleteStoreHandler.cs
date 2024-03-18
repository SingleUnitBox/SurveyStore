﻿using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;

namespace SurveyStore.Modules.Stores.Core.Commands.Handlers
{
    public class DeleteStoreHandler : ICommandHandler<DeleteStore>
    {
        private readonly IStoreRepository _storeRepository;

        public DeleteStoreHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task HandleAsync(DeleteStore command)
        {
            var store = await _storeRepository.GetAsync(command.Id);
            if (store is null)
            {
                throw new StoreNotFoundException(command.Id);
            }

            await _storeRepository.DeleteAsync(store);
        }
    }
}
