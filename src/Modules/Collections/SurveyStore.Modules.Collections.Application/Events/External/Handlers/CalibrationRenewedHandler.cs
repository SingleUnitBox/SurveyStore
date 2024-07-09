using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class CalibrationRenewedHandler : IEventHandler<CalibrationRenewed>
    {
        private readonly ICollectionRepository _collectionRepository;
        public CalibrationRenewedHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(CalibrationRenewed @event)
        {
            var collection = Collection.Create(Guid.NewGuid(), @event.SurveyEquipmentId);
            await _collectionRepository.AddAsync(collection);
        }
    }
}
