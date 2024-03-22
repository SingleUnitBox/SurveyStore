using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Kernel
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(params IDomainEvent[] @events);
    }
}
