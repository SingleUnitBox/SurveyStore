﻿using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class StoreUnassignedHandler : IEventHandler<SurveyEquipmentReturned>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public StoreUnassignedHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
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

            surveyEquipment.AssignStore(@event.StoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            var events = _eventMapper.MapAll(surveyEquipment.Events);
            await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
