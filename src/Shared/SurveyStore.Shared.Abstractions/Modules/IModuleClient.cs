using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Modules
{
    public interface IModuleClient
    {
        Task PublishAsync(object message);
    }
}
