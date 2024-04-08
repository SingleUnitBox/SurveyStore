using System;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    public sealed class ModuleRequestRegistration
    {
        public Type ReceiverType { get; }
        public Type ResponseType { get; }
        public Func<object, Task<object>> Action { get; }

        public ModuleRequestRegistration(Type receiverType, Type responseType, Func<object, Task<object>> action)
        {
            ReceiverType = receiverType;
            ResponseType = responseType;
            Action = action;
        }
    }
}
