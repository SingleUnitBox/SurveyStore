using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public class CollectionPolicy : ICollectionPolicy
    {
        public bool CanBeReturned(Collection collection, Surveyor surveyor)
        {
            throw new System.NotImplementedException();
        }
    }
}
