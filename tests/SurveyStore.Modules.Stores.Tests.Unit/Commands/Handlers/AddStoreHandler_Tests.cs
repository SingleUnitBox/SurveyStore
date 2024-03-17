using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.Commands;
using SurveyStore.Modules.Stores.Core.Commands.Handlers;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Infrastructure.Time;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Commands.Handlers
{
    public class AddStoreHandler_Tests
    {
        private Task Act(AddStore command) => _commandHandler.HandleAsync(command);

        [Fact]
        public async Task given_already_existing_store_add_async_should_fail()
        {
            var command = new AddStore("test", "testLocation", _clock.Current(), _clock.Current().AddHours(8));
            var store = new Store
            {
                Id = command.Id
            };

            _storeRepository.GetAsync(store.Id).Returns(Task.FromResult<Store>(store));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreAlreadyExistsException>();
        }

        private readonly ICommandHandler<AddStore> _commandHandler;
        private readonly IStoreRepository _storeRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IClock _clock;
        public AddStoreHandler_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _messageBroker = Substitute.For<IMessageBroker>();
            _commandHandler = new AddStoreHandler(_storeRepository, _messageBroker);
            _clock = new ClockUtc();
        }
    }
}
