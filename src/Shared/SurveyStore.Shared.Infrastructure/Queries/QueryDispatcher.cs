using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Shared.Infrastructure.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var queryHandlerType = typeof(IQueryHandler<,>)
                    .MakeGenericType(query.GetType(), typeof(TResult));
                var queryHandler = scope.ServiceProvider.GetRequiredService(queryHandlerType);

                return await (Task<TResult>)queryHandlerType
                    .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
                    ?.Invoke(queryHandler, new[] { query });
            }
        }
    }
}
