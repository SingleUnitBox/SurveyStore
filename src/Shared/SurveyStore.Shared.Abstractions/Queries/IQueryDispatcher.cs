using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery;
    }
}
