using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Moduless
{
    public interface IModulessClient
    {
        Task PublishAsync(object message);
    }
}