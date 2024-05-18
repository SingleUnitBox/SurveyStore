using System;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Postgres
{
    public interface IUnitOfWork
    {
        Task ExecuteAsync(Func<Task> action);
    }
}