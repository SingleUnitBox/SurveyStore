using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyStore.Shared.Infrastructure.Postgres
{
    public abstract class PostgresUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _dbContext;

        public PostgresUnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ExecuteAsync(Func<Task> action)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}