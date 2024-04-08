using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Modules
{
    public interface IModuleClient
    {
        Task<TResult> SendAsync<TResult>(string path, object request) where TResult : class;
        Task PublishAsync(object message);
    }
}
