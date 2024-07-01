using Microsoft.AspNetCore.Cors.Infrastructure;
using SurveyStore.Shared.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Moduless
{
    public interface IMyModuleRegistry
    {
        void AddBroadcastAction(Type requestType, Func<object, Task> action);
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string key);
    }
}
