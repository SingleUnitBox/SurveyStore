using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SurveyStore.Shared.Abstractions.Contexts;

namespace SurveyStore.Shared.Infrastructure.Contexts
{
    public class Context : IContext
    {
        public string RequestId { get; } = $"{Guid.NewGuid():N}";
        public string TraceId { get; }
        public IIdentityContext Identity { get; }
        public Context()
        {
            
        }

        public Context(HttpContext context)
            : this(context.TraceIdentifier, new IdentityContext(context.User))
        {
            
        }

        public Context(string traceId, IIdentityContext identity)
        {
            TraceId = traceId;
            Identity = identity;
        }

        public static IContext Empty => new Context();
    }
}
