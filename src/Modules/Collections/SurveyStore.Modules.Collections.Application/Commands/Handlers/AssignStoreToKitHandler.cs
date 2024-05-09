using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreToKitHandler : ICommandHandler<AssignStoreToKit>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IKitRepository _kitRepository;

        public AssignStoreToKitHandler(ICollectionRepository collectionRepository, 
            IKitRepository kitRepository)
        {            
            _collectionRepository = collectionRepository;
            _kitRepository = kitRepository;
        }

        public Task HandleAsync(AssignStoreToKit command)
        {
            throw new System.NotImplementedException();
        }
    }
}
