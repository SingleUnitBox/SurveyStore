using SurveyStore.Shared.Abstractions.Contexts;

namespace SurveyStore.Shared.Infrastructure.Contexts
{
    public interface IContextFactory
    {
        IContext Create();
    }
}
