using Microsoft.AspNetCore.Http;
using SurveyStore.Shared.Abstractions.Contexts;

namespace SurveyStore.Shared.Infrastructure.Contexts
{
    public class ContextFactory : IContextFactory
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ContextFactory(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public IContext Create()
        {
            var context = _contextAccessor.HttpContext;

            return context is null ? Context.Empty : new Context(context);
        }
    }
}