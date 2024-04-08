using System;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Modules;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    internal sealed class ModuleSubscriber : IModuleSubscriber
    {
        private readonly IModuleRegistry _moduleRegistry;
        private readonly IServiceProvider _serviceProvider;

        public ModuleSubscriber(IModuleRegistry moduleRegistry,
            IServiceProvider serviceProvider)
        {
            _moduleRegistry = moduleRegistry;
            _serviceProvider = serviceProvider;
        }
        public IModuleSubscriber Subscribe<TRequest, TResponse>(string path,
            Func<TRequest, IServiceProvider, Task<TResponse>> action)
            where TRequest : class where TResponse : class
        {
            _moduleRegistry.AddRequestAction(path, typeof(TRequest), typeof(TResponse),
                async request => await action((TRequest)request, _serviceProvider));

            return this;
        }
    }
}
