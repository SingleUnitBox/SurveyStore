using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    public interface IModuleRegistry
    {
        void AddBroadcastAction(Type requestType, Func<object, Task> action);
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string key);
    }
}
