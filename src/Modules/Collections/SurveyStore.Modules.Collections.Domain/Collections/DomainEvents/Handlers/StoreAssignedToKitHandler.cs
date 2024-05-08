using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class StoreAssignedToKitHandler : IDomainEventHandler<StoreAssignedToKit>
    {
        private readonly ICollectionRepository _collectionRepository;

        public StoreAssignedToKitHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(StoreAssignedToKit @event)
        {

        }
    }
}
