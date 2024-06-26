using SurveyStore.Modules.Equipment.Application.Kit.Events;
using SurveyStore.Modules.Equipment.Application.Kit.Exceptions;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Modules.Equipment.Domain.Kit.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Kit.Commands.Handlers
{
    public class AddKitHandler : ICommandHandler<AddKit>
    {
        private readonly IKitRepository _kitRepository;
        private readonly IMessageBroker _messageBroker;

        public AddKitHandler(IKitRepository kitRepository,
            IMessageBroker messageBroker)
        {
            _kitRepository = kitRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddKit command)
        {
            var kitTypes = KitTypes.GetKitTypes();
            if (!kitTypes.Contains(command.KitType))
            {
                throw new InvalidKitTypeException(command.KitType);
            }

            var kit = await _kitRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (kit is not null)
            {
                throw new KitAlreadyExistsException(command.KitType, command.SerialNumber);
            }

            kit = command.KitType switch
            {
                KitTypes.Tripod => Tripod.Create(command.Id, command.Brand, command.Model, command.SerialNumber, command.PurchasedAt),
                KitTypes.TraversePrism => TraversePrism.Create(command.Id, command.Brand, command.Model, command.SerialNumber, command.PurchasedAt),
                KitTypes.DetailPole => DetailPole.Create(command.Id, command.Brand, command.Model, command.SerialNumber, command.PurchasedAt),
                KitTypes.GNSSPole => GNSSPole.Create(command.Id, command.Brand, command.Model, command.SerialNumber, command.PurchasedAt),
                _ => throw new ArgumentNullException()
            };

            await _kitRepository.AddAsync(kit);
            await _messageBroker.PublishAsync(new KitCreated(kit.Id));
        }
    }
}
