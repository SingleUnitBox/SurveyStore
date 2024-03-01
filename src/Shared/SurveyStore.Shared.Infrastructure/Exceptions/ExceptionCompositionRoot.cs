using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public class ExceptionCompositionRoot : IExceptionCompositionRoot
    {
        private readonly IServiceProvider _serviceProvider;

        public ExceptionCompositionRoot(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ExceptionResponse Map(Exception exception)
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var mappers = scope.ServiceProvider.GetServices<IExceptionToResponseMapper>().ToArray();
                var nonDefaultMappers = mappers
                    .Where(m => m is not ExceptionToResponseMapper);
                var result = nonDefaultMappers.Select(m => m.Map(exception))
                    .SingleOrDefault(x => x is not null);
                if (result is not null)
                {
                    return result;
                }

                var defaultMapper = mappers.SingleOrDefault(m => m is ExceptionToResponseMapper);

                return defaultMapper?.Map(exception);
            }
        }
    }
}
