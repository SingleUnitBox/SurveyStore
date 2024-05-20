using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public interface ICollectionPolicy
    {
        bool CanBeReturned(Collection collection, Surveyor surveyor);
    }
}
