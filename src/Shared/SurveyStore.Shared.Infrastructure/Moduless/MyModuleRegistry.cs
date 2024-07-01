using SurveyStore.Shared.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Moduless
{
    internal sealed class MyModuleRegistry : IMyModuleRegistry
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
    }
}