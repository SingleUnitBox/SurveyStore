using System;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    public sealed class ModuleRequestRegistration
    {
        public Type ReceiverType { get; }
        public Type ResponseType { get; }
        public Func<object, Task<object>> Action { get; }
    }
}
