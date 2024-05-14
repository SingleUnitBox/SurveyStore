using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Modules.Equipment.Application.Kit.Mappings;
using SurveyStore.Modules.Equipment.Application.Kit.Queries;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class BrowseKitHandler : IQueryHandler<BrowseKit, IReadOnlyCollection<KitDto>>
    {
        private readonly DbSet<Kit> _kit;
        public BrowseKitHandler(EquipmentDbContext dbContext)
        {
            _kit = dbContext.Kit;
        }
        public async Task<IReadOnlyCollection<KitDto>> HandleAsync(BrowseKit query)
            => await _kit
                .AsNoTracking()
                .Select(k => k.AsDto())
                .ToListAsync();
    }
}
