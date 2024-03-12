using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _registry;
        private readonly IModuleSerializer _serializer;

        public ModuleClient(IModuleRegistry registry)
        {
            _registry = registry;
        }
        public Task PublishAsync(object message)
        {
            throw new System.NotImplementedException();
        }
    }
}
