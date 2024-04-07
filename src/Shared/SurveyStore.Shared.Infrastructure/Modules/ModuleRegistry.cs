using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    internal sealed class ModuleRegistry : IModuleRegistry
    {
        private readonly List<ModuleBroadcastRegistration> _broadcastRegistrations = new();
        public void AddBroadcastAction(Type requestType, Func<object, Task> action)
        {
            if (string.IsNullOrWhiteSpace(requestType.Namespace))
            {
                throw new InvalidOperationException("Missing namespace.");
            }

            var broadcastRegistration = new ModuleBroadcastRegistration(requestType, action);
            _broadcastRegistrations.Add(broadcastRegistration);
        }

        public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string key)
            => _broadcastRegistrations.Where(br => br.Key == key);

        public void AddRequestAction(string path, Type requestType, Type responseType, Func<object, Task<object>> action)
        {
            throw new NotImplementedException();
        }

        public ModuleRequestRegistration GetRequestRegistration(string path)
        {
            throw new NotImplementedException();
        }
    }
}
