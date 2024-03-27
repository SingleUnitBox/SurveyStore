using System.Linq;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreHandler : ICommandHandler<AssignStore>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public AssignStoreHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AssignStore command)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.Id);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.Id);
            }

            var store = await _storeRepository.GetByIdAsync(command.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreId);
            }

            surveyEquipment.AssignStore(command.StoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            var events = _eventMapper.MapAll(surveyEquipment.Events);
            await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
