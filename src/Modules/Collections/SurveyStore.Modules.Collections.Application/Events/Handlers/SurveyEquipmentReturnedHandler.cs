using Microsoft.EntityFrameworkCore.Query.Internal;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class SurveyEquipmentReturnedHandler : IEventHandler<SurveyEquipmentReturned>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public SurveyEquipmentReturnedHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(SurveyEquipmentReturned @event)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(@event.SurveyEquipmentId.Value);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(@event.SurveyEquipmentId);
            }

            var store = await _storeRepository.GetByIdAsync(@event.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.StoreId);
            }

            surveyEquipment.AssignStore(store.Id);

            var events = _eventMapper.MapAll(surveyEquipment.Events);
            await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
