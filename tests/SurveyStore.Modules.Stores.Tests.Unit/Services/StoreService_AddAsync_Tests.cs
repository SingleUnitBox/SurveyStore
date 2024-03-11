using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Modules.Stores.Core.Services;
using System;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Events;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Services
{
    public class StoreService_AddAsync_Tests
    {
        private Task Act(StoreDto storeDto) => _storeService.AddAsync(storeDto);

        [Fact]
        public async Task given_already_existing_store_add_async_should_fail()
        {
            var store = new Store
            {
                Id = Guid.NewGuid(),
            };

            _storeRepository.GetAsync(store.Id).Returns(Task.FromResult<Store>(store));

            var exception = await Record.ExceptionAsync(() => Act(new StoreDto { Id = store.Id }));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreAlreadyExistsException>();
        }

        [Fact]
        public async Task given_invalid_operation_hours_add_async_should_fail()
        {
            var storeDto = new StoreDto
            {
                Id = Guid.NewGuid(),
                OpeningTime = new DateTime(2024, 1, 1, 08, 0, 0),
                ClosingTime = new DateTime(2024, 1, 1, 06, 0, 0),
            };

            var exception = await Record.ExceptionAsync(() => Act(storeDto));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidOperationTimeException>();
        }

        [Fact]
        public async Task given_valid_store_add_async_should_succeed()
        {
            var storeDto = new StoreDto
            {
                Id = Guid.NewGuid(),
                Name = "test name",
                Location = "test location",
                OpeningTime = new DateTime(2024, 1, 1, 8, 0, 0),
                ClosingTime = new DateTime(2024, 1, 1, 17, 30, 0)
            };

            await Act(storeDto);

            await _storeRepository.Received(1).AddAsync(
                Arg.Is<Store>(x => x.Id == storeDto.Id));

        }

        private readonly IStoreService _storeService;
        private readonly IStoreRepository _storeRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public StoreService_AddAsync_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _eventDispatcher = Substitute.For<IEventDispatcher>();
            _storeService = new StoreService(_storeRepository, _eventDispatcher);
        }
    }
}
