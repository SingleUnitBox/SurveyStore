using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class KitCollectedHandler : IEventHandler<KitCollected>
    {
        private readonly IKitRepository _kitRepository;

        public KitCollectedHandler(IKitRepository kitRepository)
        {
            _kitRepository = kitRepository;
        }

        public async Task HandleAsync(KitCollected @event)
        {
            var kit = await _kitRepository.GetByIdAsync(@event.KitId.Value);
            if (kit is null)
            {
                throw new KitNotFoundException(@event.KitId);
            }

            //kit.UnassignStore();
            await _kitRepository.UpdateAsync(kit);
        }
    }
}
