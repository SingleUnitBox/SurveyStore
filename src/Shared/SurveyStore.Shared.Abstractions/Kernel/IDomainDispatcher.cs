using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Kernel
{
    public interface IDomainDispatcher
    {
        Task DispatchAsync(params IDomainEvent[] @events);
    }
}
