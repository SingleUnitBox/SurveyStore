using System;
using NSubstitute;
using SurveyStore.Modules.Stores.Core.Commands;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using Shouldly;
using SurveyStore.Modules.Stores.Core.Commands.Handlers;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Commands.Handlers
{
    public class DeleteStoreHandler_Tests
    {
        private Task Act(DeleteStore command) => _commandHandler.HandleAsync(command);

        [Fact]
        public async Task given_non_existing_store_delete_async_should_fail()
        {
            var id = Guid.NewGuid();
            _storeRepository.GetAsync(id).Returns(Task.FromResult<Store>(null));

            var exception = await Record.ExceptionAsync(() => Act(new DeleteStore(id)));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreNotFoundException>();
        }

        [Fact]
        public async Task given_existing_store_delete_async_should_succeed()
        {
            var store = new Store
            {
                Id = Guid.NewGuid(),
            };
            _storeRepository.GetAsync(store.Id).Returns(Task.FromResult<Store>(store));

            await Act(new DeleteStore(store.Id));

            await _storeRepository.Received(1)
                .DeleteAsync(Arg.Is<Store>(s => s.Id == store.Id));
        }

        private readonly ICommandHandler<DeleteStore> _commandHandler;
        private readonly IStoreRepository _storeRepository;
        public DeleteStoreHandler_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _commandHandler = new DeleteStoreHandler(_storeRepository);
        }
    }
}
