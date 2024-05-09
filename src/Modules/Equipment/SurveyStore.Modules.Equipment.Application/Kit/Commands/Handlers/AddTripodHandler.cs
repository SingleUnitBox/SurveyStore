using SurveyStore.Modules.Equipment.Application.Kit.Events;
using SurveyStore.Modules.Equipment.Application.Kit.Exceptions;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Modules.Equipment.Domain.Kit.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Kit.Commands.Handlers
{
    internal class AddTripodHandler : ICommandHandler<AddTripod>
    {
        private readonly IKitRepository _kitRepository;
        private readonly IMessageBroker _messageBroker;
        public AddTripodHandler(IKitRepository kitRepository,
            IMessageBroker messageBroker)
        {
            _kitRepository = kitRepository;
            _messageBroker = messageBroker;
        }
        public async Task HandleAsync(AddTripod command)
        {
            var tripod = await _kitRepository.GetBySerialNumberAsync(command.serialNumber);
            if (tripod is not null)
            {
                throw new KitAlreadyExistsException(tripod.GetType().Name, command.serialNumber);
            }

            tripod = Tripod.Create(command.Id, command.brand, command.model, command.serialNumber, command.purchasedAt);
            await _kitRepository.AddAsync(tripod);

            await _messageBroker.PublishAsync(new KitCreated(command.Id));
        }
    }
}
