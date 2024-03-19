using System;
using System.Threading.Tasks;
using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.Commands;
using SurveyStore.Modules.Stores.Core.Commands.Handlers;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Commands.Handlers
{
    public class UpdateStoreHandler_Tests
    {
        private Task Act(UpdateStore command) => _handler.HandleAsync(command);

        [Fact]
        public async Task given_non_existing_store_update_async_should_fail()
        {
            var command = new UpdateStore(Guid.NewGuid(), new DateTime(2024, 1, 1), new DateTime(2024, 1, 1));

            _storeRepository.GetAsync(command.Id).Returns(Task.FromResult<Store>(null));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreNotFoundException>();
        }

        [Fact]
        public async Task given_invalid_operation_hours_update_async_should_fail()
        {
            var command = new UpdateStore
            (
                Guid.NewGuid(),
                new DateTime(2024, 1, 1, 08, 0, 0),
                new DateTime(2024, 1, 1, 06, 0, 0)
            );
            _storeRepository.GetAsync(command.Id).Returns(new Store { Id = command.Id });

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidOperationTimeException>();
        }

        private readonly UpdateStoreHandler _handler;
        private readonly IStoreRepository _storeRepository;

        [Fact]
        public async Task given_valid_data_update_async_should_succeed()
        {
            var command = new UpdateStore
            (
                Guid.NewGuid(),
                new DateTime(2024, 1, 1, 8, 0, 0),
                new DateTime(2024, 1, 1, 17, 0, 0)
            );
            var store = new Store
            {
                Id = command.Id,
                Name = "test name",
                Location = "test location",
                OpeningTime = command.OpeningTime,
                ClosingTime = command.ClosingTime,
            };
            _storeRepository.GetAsync(store.Id).Returns(store);

            await Act(command);

            await _storeRepository.Received(1)
                .UpdateAsync(Arg.Is<Store>(x => x.Id == store.Id));
        }

        public UpdateStoreHandler_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _handler = new UpdateStoreHandler(_storeRepository);
        }
    }
}
