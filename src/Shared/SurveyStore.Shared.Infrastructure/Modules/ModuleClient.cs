using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _registry;
        private readonly IModuleSerializer _serializer;

        public ModuleClient(IModuleRegistry registry,
            IModuleSerializer serializer)
        {
            _registry = registry;
            _serializer = serializer;
        }
        public Task PublishAsync(object message)
        {
            throw new System.NotImplementedException();
        }
    }
}
