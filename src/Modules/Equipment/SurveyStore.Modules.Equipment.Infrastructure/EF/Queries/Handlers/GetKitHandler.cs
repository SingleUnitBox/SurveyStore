using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Modules.Equipment.Application.Kit.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class GetKitHandler : IQueryHandler<GetKit, KitDto>
    {
        public Task<KitDto> HandleAsync(GetKit query)
        {
            return Task.FromResult(new KitDto());
        }
    }
}
