using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Modules.Equipment.Application.Kit.Exceptions;
using SurveyStore.Modules.Equipment.Application.Kit.Mappings;
using SurveyStore.Modules.Equipment.Application.Kit.Queries;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class GetKitHandler : IQueryHandler<GetKit, KitDto>
    {
        private readonly DbSet<Kit> _kit;
        public GetKitHandler(EquipmentDbContext dbContext)
        {
            _kit = dbContext.Kit;
        }
        public async Task<KitDto> HandleAsync(GetKit query)
        {
            var kit = await _kit
                .AsNoTracking()
                .SingleOrDefaultAsync(k => k.Id == query.Id);

            return kit is null
                ? throw new KitNotFoundException(query.Id)
                : kit.AsDto();
        }
    }
}
